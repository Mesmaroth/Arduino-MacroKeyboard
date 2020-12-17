#include <HID-Project.h>

const int pin_led = 2;
const int push_button_1 = 3;
const int push_button_2 = 4;
const int push_button_3 = 5;
const int push_button_4 = 6;
const int push_button_5 = 7;
const int push_button_6 = 8;

void setup() {
  pinMode(pin_led, OUTPUT);
  pinMode(push_button_1, INPUT_PULLUP);
  pinMode(push_button_2, INPUT_PULLUP);
  pinMode(push_button_3, INPUT_PULLUP);
  pinMode(push_button_4, INPUT_PULLUP);
  pinMode(push_button_5, INPUT_PULLUP);
  pinMode(push_button_6, INPUT_PULLUP);
   
  Consumer.begin();
}


void loop() {
  if (!digitalRead(push_button_1)) {
    digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_PREVIOUS);
    delay(200); // wait
    digitalWrite(pin_led, LOW);
  }
  
  if (!digitalRead(push_button_2)) {
    digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_PLAY_PAUSE);
    delay(200); // wait
    digitalWrite(pin_led, LOW);
  }
    
  if (!digitalRead(push_button_3)) {
    digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_NEXT);
    delay(200); // wait
    digitalWrite(pin_led, LOW);
  }
    
  if (!digitalRead(push_button_4)) {
    digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_PLAY_PAUSE);
    delay(200); // wait
    digitalWrite(pin_led, LOW);
  }
    
  if (!digitalRead(push_button_5)) {
    digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_PLAY_PAUSE);
    delay(200); // wait
    digitalWrite(pin_led, LOW);
  }
    
  if (!digitalRead(push_button_6)) {
    digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_PLAY_PAUSE);
    delay(200); // wait
    digitalWrite(pin_led, LOW);
  }
  
}
