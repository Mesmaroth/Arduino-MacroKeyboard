 #include <HID-Project.h>

const int push_button_1 = 3;
const int push_button_2 = 4;
const int push_button_3 = 5;
const int push_button_4 = 6;
const int push_button_5 = 7;
const int push_button_6 = 8;

const int delay_button_press = 300;

void setup() {
  pinMode(push_button_1, INPUT_PULLUP);
  pinMode(push_button_2, INPUT_PULLUP);
  pinMode(push_button_3, INPUT_PULLUP);
  pinMode(push_button_4, INPUT_PULLUP);
  pinMode(push_button_5, INPUT_PULLUP);
  pinMode(push_button_6, INPUT_PULLUP);
}


void loop() {
  if (!digitalRead(push_button_1)) {
    Consumer.begin();
    // digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_PREVIOUS);
    delay(delay_button_press);
    // digitalWrite(pin_led, LOW);
    Consumer.end();
  }
  
  if (!digitalRead(push_button_2)) {
    Consumer.begin();
    // digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_PLAY_PAUSE);
    delay(delay_button_press);
    // digitalWrite(pin_led, LOW);
    Consumer.end();
  }
    
  if (!digitalRead(push_button_3)) {
    Consumer.begin();
    // digitalWrite(pin_led, HIGH);
    Consumer.write(MEDIA_NEXT);
    delay(delay_button_press);
    // digitalWrite(pin_led, LOW);
    Consumer.end();
  }
    
  if (!digitalRead(push_button_4)) {
    Keyboard.begin();
    Keyboard.press(KEY_LEFT_CTRL);
    Keyboard.press(KEY_LEFT_ALT);
    Keyboard.press(KEY_LEFT_SHIFT);
    Keyboard.press(KEY_F5);
    delay(delay_button_press);
    Keyboard.releaseAll();
    Keyboard.end();
  }
    
  if (!digitalRead(push_button_5)) {
    Keyboard.begin();
    Keyboard.press(KEY_LEFT_CTRL);
    Keyboard.press(KEY_LEFT_ALT);
    Keyboard.press(KEY_LEFT_SHIFT);
    Keyboard.press(KEY_F6);
    delay(delay_button_press);
    Keyboard.releaseAll();
    Keyboard.end();
  }
    
  if (!digitalRead(push_button_6)) {
    Keyboard.begin();
    Keyboard.press(KEY_LEFT_CTRL);
    Keyboard.press(KEY_LEFT_ALT);
    Keyboard.press(KEY_LEFT_SHIFT);
    Keyboard.press(KEY_F7);
    delay(delay_button_press);
    Keyboard.releaseAll();
    Keyboard.end();
  }
}
