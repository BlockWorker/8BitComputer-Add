#define SH_CLR 2
#define SH_CLK 3
#define SH_PUSH 4
#define SH_DATA 5
#define MEM_WRITE 6

#define IN_WRITE_INV 7
#define IN_ACTIVE 8
#define IN_DATA_0 9
#define IN_DATA_1 10
#define IN_DATA_2 11
#define IN_DATA_3 12
#define IN_DATA_4 A0
#define IN_DATA_5 A1
#define IN_DATA_6 A2
#define IN_DATA_7 A3
#define IN_LOCK_INV A4
#define IN_PAUSE_INV A5

bool userInput = true;

void setup() {  
  pinMode(SH_CLR, OUTPUT);
  pinMode(SH_CLK, OUTPUT);
  pinMode(SH_PUSH, OUTPUT);
  pinMode(SH_DATA, OUTPUT);
  pinMode(MEM_WRITE, OUTPUT);
  digitalWrite(SH_CLR, LOW);
  digitalWrite(SH_CLR, HIGH);
  digitalWrite(SH_CLK, LOW);
  digitalWrite(SH_PUSH, LOW);
  digitalWrite(SH_DATA, LOW);
  digitalWrite(MEM_WRITE, LOW);

  pinMode(IN_LOCK_INV, OUTPUT);
  pinMode(IN_PAUSE_INV, INPUT);
  pinMode(IN_ACTIVE, INPUT);
  switchInput(true);

  Serial.begin(100000);
}

void loop() {
  processSerial();
}

void processSerial() {
  if (Serial.available() < 1) return;
  uint16_t addr;
  uint16_t len;
  byte* buf;
  int timeout;
  switch (Serial.read()) {
    case 0:
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
      for (byte i = 0; i < len; i++) {
        writeByte(addr + i, buf[i]);
      }
      delay(15);
      Serial.write(1);
      break;
    case 1:
      Serial.write(1);
      break;
    default:
      Serial.write(0);
      break;
  }
}

void writeByte(uint16_t addr, uint8_t data) {
  shiftOut(SH_DATA, SH_CLK, LSBFIRST, data);
  shiftOut(SH_DATA, SH_CLK, LSBFIRST, addr & 0xff);
  shiftOut(SH_DATA, SH_CLK, LSBFIRST, addr >> 8);
  delayMicroseconds(10);
  digitalWrite(SH_PUSH, HIGH);
  delayMicroseconds(10);
  digitalWrite(SH_PUSH, LOW);
  delayMicroseconds(10);
  digitalWrite(MEM_WRITE, HIGH);
  delayMicroseconds(10);
  digitalWrite(MEM_WRITE, LOW);
}

void switchInput(bool user) {
  userInput = user;
  if (user) {
    pinMode(IN_WRITE_INV, INPUT);
    pinMode(IN_DATA_0, INPUT);
    pinMode(IN_DATA_1, INPUT);
    pinMode(IN_DATA_2, INPUT);
    pinMode(IN_DATA_3, INPUT);
    pinMode(IN_DATA_4, INPUT);
    pinMode(IN_DATA_5, INPUT);
    pinMode(IN_DATA_6, INPUT);
    pinMode(IN_DATA_7, INPUT);
    digitalWrite(IN_LOCK_INV, HIGH);
  } else {
    pinMode(IN_WRITE_INV, OUTPUT);
    pinMode(IN_DATA_0, OUTPUT);
    pinMode(IN_DATA_1, OUTPUT);
    pinMode(IN_DATA_2, OUTPUT);
    pinMode(IN_DATA_3, OUTPUT);
    pinMode(IN_DATA_4, OUTPUT);
    pinMode(IN_DATA_5, OUTPUT);
    pinMode(IN_DATA_6, OUTPUT);
    pinMode(IN_DATA_7, OUTPUT);
    digitalWrite(IN_LOCK_INV, LOW);
    digitalWrite(IN_WRITE_INV, HIGH);
    digitalWrite(IN_DATA_0, LOW);
    digitalWrite(IN_DATA_1, LOW);
    digitalWrite(IN_DATA_2, LOW);
    digitalWrite(IN_DATA_3, LOW);
    digitalWrite(IN_DATA_4, LOW);
    digitalWrite(IN_DATA_5, LOW);
    digitalWrite(IN_DATA_6, LOW);
    digitalWrite(IN_DATA_7, LOW);
  }
}

