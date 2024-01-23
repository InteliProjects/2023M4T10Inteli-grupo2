#include <WiFi.h>
#include <WiFiClientSecure.h>
#include <Arduino.h>

namespace connection
{
    class WifiConnection
    {
        public:
        struct Config
        {
            const String ssid;
            const String password;
            const char* certificate;
        };
        
        WifiConnection(Config &wifiConfig);
        
        /**
         * @brief Returns true if wifi is not connected and false otherwise.
         */
        bool isWifiNotConnected();
        
        /**
         * @brief Initializes the WiFi connection.
         */
        void connectWifi();

        WiFiClientSecure wifiClient;

        private:
        Config wifiConfig;
    };
}