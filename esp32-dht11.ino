#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include "DHT.h"

#define DHTPIN 4 
#define DHTTYPE DHT11

DHT dht(DHTPIN, DHTTYPE);

const char* wifiAdi = "NetMASTER Uydunet-9D98";
const char* wifiSifre = "c9fb247c68de60d9";

String apiSicaklikGonder = "https://heatrequest-api.conveyor.cloud/api/values/setValue";

void setup() {
  Serial.begin(115200); 
  
  dht.begin();
  WiFi.begin(wifiAdi, wifiSifre);
  Serial.println("Baglaniliyor ...");
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Belirtilen IP Adresli WiFi ogesine baglanildi =>  ");
  Serial.println(WiFi.localIP());

  pinMode(2,OUTPUT);
 }

void loop() {
  if(WiFi.status()== WL_CONNECTED){
      WiFiClient client;
      HTTPClient http;
    
      http.begin(apiSicaklikGonder);

      http.addHeader("Content-Type", "application/json");

      float t = dht.readTemperature();
      if (isnan(t)) {
        Serial.println(F("Sicaklik sensorunden veriler okunamadi!"));
        return;
      }
       
      StaticJsonDocument<200> doc;
      doc["MakinaId"]=1;
      doc["HeatValue"]=t;

      String requestBody;
      serializeJson(doc, requestBody);

      Serial.println(requestBody);
      
      int httpResponseCode = http.POST(requestBody);

      Serial.println(httpResponseCode);
 
      if(httpResponseCode>0){
        String response = http.getString();                                
        Serial.println(httpResponseCode);   
        Serial.println(response);
      }
      else {
        Serial.println("Hata meydana geldi");
      }
  
        
      http.end();

      digitalWrite(2,HIGH);
      delay(150);
      digitalWrite(2,LOW);
    }
    else {
      Serial.println("WiFi Disconnected");
    }

    delay(1000);  
}
