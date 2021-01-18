#include <HID-Project.h>

const int push_button_1 = 4;
const int push_button_2 = 3;
const int push_button_3 = 2;
const int push_button_4 = 5;
const int push_button_5 = 6;
const int push_button_6 = 7;

int pn_array[] = {
  push_button_1,
  push_button_2,
  push_button_3,
  push_button_4,
  push_button_5,
  push_button_6
  };

String default_binds[] = {
"#mprev",
"#mplaypause",
"#mnext",
"#^!+F5",
"#^!+F6",
"#^!+F7"
};

const int release_button_delay = 30;
const int debounce_delay = 50;

int btn_config = 0;

bool wait_response = false;
int key_rebind = 0;

void setup() {
  pinMode(push_button_1, INPUT_PULLUP);
  pinMode(push_button_2, INPUT_PULLUP);
  pinMode(push_button_3, INPUT_PULLUP);
  pinMode(push_button_4, INPUT_PULLUP);
  pinMode(push_button_5, INPUT_PULLUP);
  pinMode(push_button_6, INPUT_PULLUP);

  Serial.begin(9600);
}

void loop() {
  String command = "";  
  if(Serial.available() > 0) {
    while(Serial.available() > 0) {
      command += char(Serial.read());
    }
  }

  if(wait_response) {
    command = command.substring(1);
    rebind_key(key_rebind);
    return;
  }

  command = command.substring(1,5);

  if (command == "cfg1") {
    Serial.println("Config set to 1.");
    btn_config = 0;
    return;
  } else if (command == "cfg2") {
    Serial.println("Config set to 2.");
    btn_config = 1;
    return;
  } else if (command == "cfg3") {
    btn_config = 2;
    return;
  }

  if (command == "rbd1") {
    Serial.println("Enter binds...");
    wait_response = true;
    key_rebind = 1;
    return;
  }

  if(command == "test") {
    Serial.println("Reading binds...");
    execute_bind(default_binds[5]);
    return;
  }
  
  if (!digitalRead(push_button_1) || command.equals("bton")) {
    delay(debounce_delay);
    if(digitalRead(push_button_1) || command.equals("bton")) {
      button_one();
      return;
    }
  }
  
  if (!digitalRead(push_button_2) || command.equals("bttw")) {
    delay(debounce_delay);
    if(digitalRead(push_button_2) || command.equals("bttw")) {
      button_two();
      return;
    }
  }
    
  if (!digitalRead(push_button_3) || command.equals("bttr")) {
    delay(debounce_delay);
    if(digitalRead(push_button_3) || command.equals("bttr")) {
      button_three();
      return;
    }
  }
    
  if (!digitalRead(push_button_4) || command.equals("btfr")) {
    delay(debounce_delay);
    if (digitalRead(push_button_4) || command.equals("btfr")) {
      button_four();
      return;
    }
  }
    
  if (!digitalRead(push_button_5) || command.equals("btfv")) {
    delay(debounce_delay);
    if (digitalRead(push_button_5) || command.equals("btfv")) {
      button_five();
      return;
    }
  }
    
  if (!digitalRead(push_button_6) || command.equals("btsx")) {
    delay(debounce_delay);
    if (digitalRead(push_button_6) || command.equals("btsx")) {
      button_six();
      return;
    }
  }
}

void rebind_key(int key) {
  switch(key) {
    case 1:      
      bool binding = true;
      while(binding) {
          Serial.println("Waiting for bindings");
          String bind = "";  
          if(Serial.available() > 0) {
            while(Serial.available() > 0) {
              bind += char(Serial.read());
            }
          }

          if(bind.length() > 0) {
            binding = false;
            bind = bind.substring(1);
            Serial.println(bind);
            Serial.println("Binded.");
          }
          delay(500);          
      }       
      wait_response = false;
      break;
  }
}

void execute_bind(String bind) {
  bool ctrl_bind = false;
  bool alt_bind = false;
  bool shift_bind = false;
  
  bool func_bind = false;
  String key = "";
  
  bind = bind.substring(1);
  for(int i = 0; i < bind.length(); i++) {
    if(String(bind[i]).equals("m")) {
      break;
    }
    
    if(String(bind[i]).equals("^")) {
      ctrl_bind = true;
      continue;
    }

    if(String(bind[i]).equals("!")) {
      alt_bind = true;
      continue;
    }

    if(String(bind[i]).equals("+")) {
      shift_bind = true;
      continue;
    }

    if(isAlpha(bind[i]) && String(bind[i]).equals("F")) {
      func_bind = true;
      continue;
    } else if(isAlpha(bind[i])) {
      key=bind[i];
      break;
    }

    if(func_bind) {
      key+=bind[i];     
    }    
  }
  Serial.println(ctrl_bind);
  Serial.println(alt_bind);
  Serial.println(shift_bind);
  Serial.println(func_bind);
  Serial.println(key);

  if(bind.equals("mprev")) {
    Consumer.begin();
    Consumer.write(MEDIA_PREVIOUS);
    delay(release_button_delay);
    Consumer.end();
    return;
  } else if(bind.equals("mplaypause")) {
    Consumer.begin();
    Consumer.write(MEDIA_PLAY_PAUSE);
    delay(release_button_delay);
    Consumer.end();
    return;
  } else if(bind.equals("mnext")) {
    Consumer.begin();
    Consumer.write(MEDIA_NEXT);
    delay(release_button_delay);
    Consumer.end();
    return;
  }

  Keyboard.begin();

  if(ctrl_bind) {
    Keyboard.press(KEY_LEFT_CTRL);
  }

  if(alt_bind) {
    Keyboard.press(KEY_LEFT_ALT);
  }

  if(shift_bind) {
    Keyboard.press(KEY_LEFT_SHIFT);
  }

  if(func_bind) {
    if(key.equals("1")) {
      Keyboard.press(KEY_F1);
    }
    if(key.equals("2")) {
      Keyboard.press(KEY_F2);
    }
    if(key.equals("3")) {
      Keyboard.press(KEY_F3);
    }
    if(key.equals("4")) {
      Keyboard.press(KEY_F4);
    }
    if(key.equals("5")) {
      Keyboard.press(KEY_F5);
    }
    if(key.equals("6")) {
      Keyboard.press(KEY_F6);
    }
    if(key.equals("7")) {
      Keyboard.press(KEY_F7);
    }
    if(key.equals("8")) {
      Keyboard.press(KEY_F8);
    }
    if(key.equals("9")) {
      Keyboard.press(KEY_F9);
    }
    if(key.equals("10")) {
      Keyboard.press(KEY_F10);
    }
    if(key.equals("11")) {
      Keyboard.press(KEY_F11);
    }
    if(key.equals("12")) {
      Keyboard.press(KEY_F12);
    }
  }

  delay(release_button_delay);
  Keyboard.releaseAll();
  Keyboard.end();
}

void button_one() {
  Serial.println("Button 1 pressed.");
  execute_bind(default_binds[0]);
}

void button_two() {
  Serial.println("Button 2 pressed.");
  execute_bind(default_binds[1]);
}

void button_three() {
  Serial.println("Button 3 pressed.");
  execute_bind(default_binds[2]);
}

void button_four() {
  Serial.println("Button 4 pressed.");
  execute_bind(default_binds[3]);
}

void button_five() {
  Serial.println("Button 5 pressed.");
  execute_bind(default_binds[4]);
}

void button_six() {
  Serial.println("Button 6 pressed.");
  execute_bind(default_binds[5]);
}
