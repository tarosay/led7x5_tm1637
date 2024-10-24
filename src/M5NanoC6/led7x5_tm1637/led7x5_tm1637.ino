/*
This Arduino program is designed to control a TM1637 4-digit display module and display data as a 5x7 matrix using the TM16xxMatrix library. It is tested and built for the M5 Nano C6 microcontroller, utilizing Arduino IDE 2.3.3. The program reads data through USB serial communication, converts it into binary, and then displays it on a matrix of LEDs.

Key Features:

    Utilizes the TM1637 module with a custom 5x7 matrix for display.
    Serial data input is processed and displayed on the matrix in real-time.
    LED status is toggled on each data read, providing visual feedback.
    Supports up to 390 bytes of data (MAXBYTE), with data processing occurring after receiving a sequence of 7 bytes.
    Implements functions for controlling the individual pixels of the matrix, converting input values to binary representations for display.

The program is set up to operate on the M5 Nano C6, using DIO pin 2 and CLK pin 1 for communication with the TM1637 display module. It can be easily adapted for other microcontrollers that support the TM1637 library.

The source code and further details can be found in the following GitHub repository: https://github.com/tarosay/led7x5_tm1637

This code provides a practical example of integrating a TM1637 display with M5 Nano C6 for projects requiring matrix displays or similar outputs.
*/
#include <M5NanoC6.h>
#include <TM1637.h>
#include <TM16xxMatrix.h>

#if !defined(LED_BUILTIN)
#define LED_BUILTIN 7
#endif

// Define a 4-digit display module. Pin suggestions:
// ESP8266 (Wemos D1): data pin 5 (D1), clock pin 4 (D2)
// ATtiny44A: data pin 9, clock pin 10 (LED_BUILTIN: 8)
// define a module on data pin 5 (D1), clock pin 4 (D2)
// M5NANOC6 data pin 2 (D1), clock pin 1 (D2)
#define DIO 2
#define CLK 1

TM1637 module(DIO, CLK);
#define MATRIX_NUMCOLUMNS 5
#define MATRIX_NUMROWS 7
TM16xxMatrix matrix(&module, MATRIX_NUMCOLUMNS, MATRIX_NUMROWS);  // TM16xx object, columns, rows

#define MAXBYTE 390
byte readByte[MAXBYTE];
int position = 0;
int waitMilliseconds = 1000;
unsigned long waitingLimit = 0;

void setup() {
  NanoC6.begin();
  Serial.begin(115200);
  pinMode(LED_BUILTIN, OUTPUT);     // Initialize the LED_BUILTIN pin as an output
  digitalWrite(LED_BUILTIN, HIGH);   // switch (active) low LED off
  digitalWrite(LED_BUILTIN, LOW);  // switch (active) low LED off
  delay(10);

  Serial.println(F("clear"));
  module.clearDisplay();
}

void resetData() {
  position = 0;
  readByte[0] = 0;
  waitingLimit = 0;
}

void loop() {
  // USBシリアル通信データの確認
  while (Serial.available() > 0) {
    readByte[position] = Serial.read();
    position++;

    if (position >= 7) {
      //表示する
      digitalWrite(LED_BUILTIN, HIGH);  // switch (active) low LED off
      faceDisplay();
      digitalWrite(LED_BUILTIN, LOW);  // switch (active) low LED off
      //リセット
      resetData();
    }

    if (position >= MAXBYTE) {
      //リセット
      resetData();
      break;
    }

    waitingLimit = millis() + waitMilliseconds;
  }

  if (waitingLimit == 0 || waitingLimit < millis()) {
    //リセット
    resetData();
    return;
  }
  //delay(50);
}

void faceDisplay() {
  byte c;
  for (int x = 0; x < 7; x++) {
    c = colNumber(readByte[6 - x]);
    colDisplay(x, c);
    //Serial.println(c);
  }
}

void colDisplay(int col, byte bin) {
  matrix.setPixel(4, col, (bin & 0x10) > 0);
  matrix.setPixel(3, col, (bin & 0x08) > 0);
  matrix.setPixel(2, col, (bin & 0x04) > 0);
  matrix.setPixel(1, col, (bin & 0x02) > 0);
  matrix.setPixel(0, col, (bin & 0x01) > 0);
}

byte colNumber(byte bin) {
  if (bin == '0') {
    return 0;
  } else if (bin == '1') {
    return 1;
  } else if (bin == '2') {
    return 2;
  } else if (bin == '3') {
    return 3;
  } else if (bin == '4') {
    return 4;
  } else if (bin == '5') {
    return 5;
  } else if (bin == '6') {
    return 6;
  } else if (bin == '7') {
    return 7;
  } else if (bin == '8') {
    return 8;
  } else if (bin == '9') {
    return 9;
  } else if (bin == 'a') {
    return 10;
  } else if (bin == 'b') {
    return 11;
  } else if (bin == 'c') {
    return 12;
  } else if (bin == 'd') {
    return 13;
  } else if (bin == 'e') {
    return 14;
  } else if (bin == 'f') {
    return 15;
  } else if (bin == 'g') {
    return 16;
  } else if (bin == 'h') {
    return 17;
  } else if (bin == 'i') {
    return 18;
  } else if (bin == 'j') {
    return 19;
  } else if (bin == 'k') {
    return 20;
  } else if (bin == 'l') {
    return 21;
  } else if (bin == 'm') {
    return 22;
  } else if (bin == 'n') {
    return 23;
  } else if (bin == 'o') {
    return 24;
  } else if (bin == 'p') {
    return 25;
  } else if (bin == 'q') {
    return 26;
  } else if (bin == 'r') {
    return 27;
  } else if (bin == 's') {
    return 28;
  } else if (bin == 't') {
    return 29;
  } else if (bin == 'u') {
    return 30;
  } else if (bin == 'v') {
    return 31;
  }
  return 0;
}
