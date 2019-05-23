#define SHD 2 //shift data
#define SHC 3 //shift clock
#define SRC 4 //storage clock
#define DATA_OFFSET 5
#define WE A0

#define PROGRAMCTRL //comment this out for text mode

uint8_t digits[] = { 0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7d, 0x07, 0x7f, 0x6f };

void setup() {
  digitalWrite(WE, HIGH);
  pinMode(WE, OUTPUT);
  pinMode(SHD, OUTPUT);
  pinMode(SHC, OUTPUT);
  pinMode(SRC, OUTPUT);
  digitalWrite(SHD, LOW);
  digitalWrite(SHC, LOW);
  digitalWrite(SRC, LOW);
  setPinModes(INPUT);

  #ifdef PROGRAMCTRL
  Serial.begin(100000);
  #else
  Serial.begin(9600);
  Serial.println("Commands:");
  Serial.println("read **** - returns byte of data at given address");
  Serial.println("pread **** - returns data in page starting with given bits (hex)");
  Serial.println("readall - returns all data");
  Serial.println("write **** ** - writes byte (hex 2) to given address (hex 1)");
  Serial.println("pwrite **** *x128 - writes up to 64 bytes (hex 2) to page starting with given bits (hex 1)");
  Serial.println("writeprogram - writes using programmed algorithm");
  Serial.println("disableprotect - disables software data protection");
  #endif
}

void loop() {
  #ifdef PROGRAMCTRL
  processProgramSerial();
  #else
  processTextSerial();
  #endif
}

void processProgramSerial() {
  static bool fastmode = false;
  if (Serial.available() < 1) return;
  uint16_t addr;
  uint16_t len;
  byte* buf;
  int timeout;
  switch (Serial.read()) {
    case 0:
      while (Serial.available() < 4);
      addr = (Serial.read() << 8) | Serial.read();
      len = (Serial.read() << 8) | Serial.read();
      setPinModes(INPUT);
      for (uint16_t i = addr; i < addr + len; i++) Serial.write(readByteRaw(i));
      break;
    case 1:
      timeout = 0;
      while (Serial.available() < 3) {
        timeout++;
        if (timeout > 1000) {
          Serial.write(0);
          return;
        }
        delay(1);
      }
      addr = (Serial.read() << 8) | Serial.read();
      len = Serial.read() + 1;
      buf = new byte[len];
      for (byte i = 0; i < len; i++) {
        timeout = 0;
        while (Serial.available() < 1){
          timeout++;
          if (timeout > 100000) {
            Serial.write(0);
            return;
          }
          delayMicroseconds(10);
        }
        buf[i] = Serial.read();
      }
      setPinModes(OUTPUT);
      for (byte i = 0; i < len; i++) {
        writeByteRaw(addr + i, buf[i]);
        if ((addr + i) % 64 == 63 && !fastmode) delay(11);
      }
      delay(15);
      Serial.write(1);
      break;
    case 2:
      while (Serial.available() < 1);
      fastmode = Serial.read() > 0;
      setPinModes(OUTPUT);
      writeByteRaw(0x1555, 0xAA);
      delayMicroseconds(10);
      writeByteRaw(0xAAA, 0x55);
      delayMicroseconds(10);
      writeByteRaw(0x1555, 0x80);
      delayMicroseconds(10);
      writeByteRaw(0x1555, 0xAA);
      delayMicroseconds(10);
      writeByteRaw(0xAAA, 0x55);
      delayMicroseconds(10);
      writeByteRaw(0x1555, 0x20);
      delay(10);
      Serial.write(1);
      break;
    case 3:
      Serial.write(1);
      break;
    default:
      Serial.write(0);
      break;
  }
}

void processTextSerial() {
  if (Serial.available() > 0) {
    char rec[200];
    byte z = Serial.readBytesUntil(';', rec, 200);
    if (z > 140) return;
    rec[z] = 0;
    String str = String(rec);
    if (str.startsWith("read") && str.length() >= 9) {
      uint16_t addr = (uint16_t)strtol(str.substring(5, 9).c_str(), NULL, 16);
      byte data = readByte(addr);
      Serial.print("Data at 0x");
      Serial.print(String(addr, HEX));
      Serial.print(" is 0x");
      Serial.println(String(data, HEX));
    } else if (str.startsWith("readall")) {
      setPinModes(INPUT);
      Serial.println("All Data:");
      for (int i = 0; i < 8192; i++) {
        byte data = readByteRaw(i);
        if (data < 0x10) Serial.print(0);
        Serial.print(String(data, HEX));
        if (i % 32 == 31) Serial.println();
        else Serial.print(" ");
      }
    } else if (str.startsWith("pread") && str.length() >= 10) {
      uint16_t addr = (uint16_t)strtol(str.substring(6, 10).c_str(), NULL, 16);
      addr &= 0x7FC0;
      setPinModes(INPUT);
      Serial.print("Data from block 0x");
      Serial.println(String(addr, HEX));
      for (int i = addr; i - addr < 64; i++) {
        byte data = readByteRaw(i);
        if (data < 0x10) Serial.print(0);
        Serial.print(String(data, HEX));
        if (i % 16 == 15) Serial.println();
        else Serial.print(" ");
      }
    } else if (str.startsWith("write") && str.length() >= 13) {
      uint16_t addr = (uint16_t)strtol(str.substring(6, 10).c_str(), NULL, 16);
      byte data = (byte)strtol(str.substring(11, 13).c_str(), NULL, 16);
      Serial.print("Writing 0x");
      Serial.print(String(data, HEX));
      Serial.print(" to 0x");
      Serial.println(String(addr, HEX));
      writeByte(addr, data);
      byte nData = readByte(addr);
      if (nData == data) Serial.println("Write successful");
      else {
        Serial.print("Write failed, stored data is 0x");
        Serial.println(String(nData, HEX));
      }
    } else if (str.startsWith("pwrite") && str.length() >= 16 && str.length() <= 140 && str.length() % 2 == 0) {
      uint16_t addr = (uint16_t)strtol(str.substring(7, 11).c_str(), NULL, 16);
      addr &= 0x7FC0;
      byte dataLength = (str.length() - 12) / 2;
      setPinModes(OUTPUT);
      Serial.print("Writing ");
      Serial.print(dataLength);
      Serial.print(" bytes to page 0x");
      Serial.println(String(addr, HEX));
      byte index = 12;
      for (int16_t i = addr; i - addr < dataLength; i++) {
        byte data = (byte)strtol(str.substring(index, index + 2).c_str(), NULL, 16);
        writeByteRaw(i, data);
        delayMicroseconds(10);
        index += 2;
      }
      delayMicroseconds(1);
      delay(10);
      setPinModes(INPUT);
      Serial.println("Page data is now:");
      for (int i = addr; i - addr < 64; i++) {
        byte data = readByteRaw(i);
        if (data < 0x10) Serial.print(0);
        Serial.print(String(data, HEX));
        if (i % 16 == 15) Serial.println();
        else Serial.print(" ");
      }
    } else if (str.startsWith("writeprogram")) {
      Serial.println("Writing programmed data...");
      writeProgram();
      Serial.println("Write done.");
    } else if (str.startsWith("disableprotect")) {
      setPinModes(OUTPUT);
      Serial.println("Disabling software data protection");
      writeByteRaw(0x1555, 0xAA);
      delayMicroseconds(10);
      writeByteRaw(0xAAA, 0x55);
      delayMicroseconds(10);
      writeByteRaw(0x1555, 0x80);
      delayMicroseconds(10);
      writeByteRaw(0x1555, 0xAA);
      delayMicroseconds(10);
      writeByteRaw(0xAAA, 0x55);
      delayMicroseconds(10);
      writeByteRaw(0x1555, 0x20);
      delay(10);
    }
  }
}

void writeProgram() {
  setPinModes(OUTPUT);
  //UNSIGNED
  uint16_t addr = 0x0300;
  for (int i = 0; i <= 0xff; i++) {
    writeByteRaw(addr + i, digits[i % 10]);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0200;
  for (int i = 0; i <= 0xff; i++) {
    writeByteRaw(addr + i, digits[(i / 10) % 10]);
    //delay(10);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0100;
  for (int i = 0; i <= 0xff; i++) {
    writeByteRaw(addr + i, digits[i / 100]);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0000;
  for (int i = 0; i <= 0xff; i++) {
    writeByteRaw(addr + i, 0x00);
    if ((addr + i) % 64 == 63) delay(15);
  }
  
  //SIGNED
  addr = 0x0700;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, digits[i % 10]);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0780;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, digits[abs(i - 0x80) % 10]);
    //delay(5);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0600;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, digits[(i / 10) % 10]);
    //delay(10);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0680;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, digits[(abs(i - 0x80) / 10) % 10]);
    //delay(10);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0500;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, digits[i / 100]);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0580;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, digits[abs(i - 0x80) / 100]);
    //delay(5);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0400;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, 0x00);
    if ((addr + i) % 64 == 63) delay(15);
  }
  addr = 0x0480;
  for (int i = 0; i <= 0x7f; i++) {
    writeByteRaw(addr + i, 0x40);
    if ((addr + i) % 64 == 63) delay(15);
  }
}

void setPinModes(byte mode) {
  for (byte i = DATA_OFFSET; i - DATA_OFFSET < 8; i++) {
    pinMode(i, mode);
    digitalWrite(i, LOW);
  }
}

void doShift(uint16_t addr, bool _write) {
  bitWrite(addr, 15, _write);
  shiftOut(SHD, SHC, LSBFIRST, addr & 0xff);
  shiftOut(SHD, SHC, LSBFIRST, addr >> 8);
  digitalWrite(SRC, HIGH);
  digitalWrite(SRC, LOW);
}

byte readByte(uint16_t addr) {
  setPinModes(INPUT);
  return readByteRaw(addr);
}

byte readByteRaw(uint16_t addr) {
  doShift(addr, false);
  delayMicroseconds(5);
  byte data = 0;
  for (byte j = 0; j < 8; j++) bitWrite(data, j, digitalRead(j + DATA_OFFSET));
  delayMicroseconds(5);
  return data;
}

void writeByte(uint16_t addr, byte data) {
  setPinModes(OUTPUT);
  writeByteRaw(addr, data);
  delay(11);
}

void writeByteRaw(uint16_t addr, byte data) {
  doShift(addr, true);
  delayMicroseconds(5);
  digitalWrite(WE, LOW);
  for (byte j = 0; j < 8; j++) digitalWrite(j + DATA_OFFSET, bitRead(data, j));
  delayMicroseconds(5);
  digitalWrite(WE, HIGH);
  //delay(11);
}

