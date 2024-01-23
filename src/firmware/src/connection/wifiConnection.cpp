#include "connection/wifiConnection.hpp"

using namespace connection;

WifiConnection::WifiConnection(Config &wifiConfig) : wifiConfig(wifiConfig)
{
    wifiClient.setCACert(wifiConfig.certificate);
}

void WifiConnection::connectWifi()
{
    WiFi.mode(WIFI_STA);
    WiFi.begin(wifiConfig.ssid, wifiConfig.password);
    Serial.print("Conectando-se à rede: ");
    Serial.print(wifiConfig.ssid);
    
    while (isWifiNotConnected())
    {
    delay(500);
    Serial.print(".");
    }

    Serial.println("Conectado ao Wifi. IP: " + WiFi.localIP().toString());
}

bool WifiConnection::isWifiNotConnected()
{
    return WiFi.status() != WL_CONNECTED;
}