#include "config/config.hpp"

bool isRunning = true;

void setup() {
  Serial.begin(9600);
  // MQTTStateMachine.init(); // official code
  MQTTStateMachine.initTestVersion(); // test version
}

void loop() {
  if (isRunning)
  {
    MQTTStateMachine.loop();
  }

  if (deactivateSystemButton.isPressed())
  {
    isRunning = false;
    Serial.println("Sistema interrompido. Nenhuma tag sendo lida ou mensagem sendo enviada.");
    delay(500);
  }

  if (activateSystemButton.isPressed())
  {
    isRunning = true;
    Serial.println("Sistema ativo!");
  }

}
