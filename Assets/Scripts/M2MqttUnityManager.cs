using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using TMPro;

namespace M2MqttUnity.Examples
{

    public class M2MqttUnityManager : M2MqttUnityClient
    {
   
        [Tooltip("Set this to true to perform a testing cycle automatically on startup")]
        public bool autoTest = false;
        public TextMeshPro inputVoltage, faultVoltage, batteryVoltage, outputVoltage, inputFrequency, temperature, outputCurrent;
        public GameObject mesh1, mesh2, mesh3, mesh4, mesh5, mesh6, mesh7, mesh8;
        public GameObject meshAlert1, meshAlert2, meshAlert3, meshAlert4, meshAlert5, meshAlert6, meshAlert7, meshAlert8;
        private List<MqttMsgPublishEventArgs> eventMessages = new List<MqttMsgPublishEventArgs>();

        public void TestPublish()
        {
            // client.Publish("M2MQTT_Unity/testrahul", System.Text.Encoding.UTF8.GetBytes("Test message"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("Test message published");
        }

        public void SetBrokerAddress(string brokerAddress)
        {
                this.brokerAddress = brokerAddress;
        }

        public void SetBrokerPort(string brokerPort)
        {
                int.TryParse(brokerPort, out this.brokerPort);
        }

        public void SetEncrypted(bool isEncrypted)
        {
            this.isEncrypted = isEncrypted;
        }

        protected override void OnConnecting()
        {
            base.OnConnecting();
        }

        protected override void OnConnected()
        {
            base.OnConnected();

            if (autoTest)
            {
                TestPublish();
            }
        }

        protected override void SubscribeTopics()
        {
            client.Subscribe(new string[] { "/UPS/input_voltage" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/fault_voltage" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/battery_voltage" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/output_voltage" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/input_frequency" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/Temperature" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/output_current" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            client.Subscribe(new string[] { "/UPS/utility_fail" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/battery_low" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/buck" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/ups_failed" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/standby" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/test" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/shutdown" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "/UPS/beeper" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        protected override void UnsubscribeTopics()
        {
            // client.Unsubscribe(new string[] { "M2MQTT_Unity/test" });
        }

        protected override void OnConnectionFailed(string errorMessage)
        {

        }

        protected override void OnDisconnected()
        {

        }

        protected override void OnConnectionLost()
        {

        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void DecodeMessage(MqttMsgPublishEventArgs message)
        {
            // string msg;
            // msg = System.Text.Encoding.UTF8.GetString(message.);
            // Debug.Log("Received: " + msg);
            StoreMessage(message);
            if (message.Topic == "M2MQTT_Unity/test")
            {
                if (autoTest)
                {
                    autoTest = false;
                    Disconnect();
                }
            }
        }

        private void StoreMessage(MqttMsgPublishEventArgs message)
        {
            eventMessages.Add(message);
        }

        public void UpdateValues(string topic,string value)
        {
            if (topic == "/UPS/input_voltage")
                inputVoltage.text = value;
            if (topic == "/UPS/fault_voltage")
                faultVoltage.text = value;
            if (topic == "/UPS/battery_voltage")
                batteryVoltage.text = value;
            if (topic == "/UPS/output_voltage")
                outputVoltage.text = value;
            if (topic == "/UPS/input_frequency")
                inputFrequency.text = value;
            if (topic == "/UPS/Temperature")
                temperature.text = value;
            if (topic == "/UPS/output_current")
                outputCurrent.text = value;

            if (topic == "/UPS/utility_fail")
            {
                if (value == "1")
                    ChangeColor(mesh1, meshAlert1, true);
                else
                    ChangeColor(mesh1, meshAlert1, false);
            }
            if (topic == "/UPS/battery_low")
            {
                if (value == "1")
                    ChangeColor(mesh2, meshAlert2, true);
                else
                    ChangeColor(mesh2, meshAlert2, false);
            }
            if (topic == "/UPS/buck")
            {
                if (value == "1")
                    ChangeColor(mesh3, meshAlert3, true);
                else
                    ChangeColor(mesh3, meshAlert3, false);
            }
            if (topic == "/UPS/ups_failed")
            {
                if (value == "1")
                    ChangeColor(mesh4, meshAlert4, true);
                else
                    ChangeColor(mesh4, meshAlert4, false);
            }
            if (topic == "/UPS/standby")
            {
                if (value == "1")
                    ChangeColor(mesh5, meshAlert5, true);
                else
                    ChangeColor(mesh5, meshAlert5, false);
            }
            if (topic == "/UPS/test")
            {
                if (value == "1")
                    ChangeColor(mesh6, meshAlert6, true);
                else
                    ChangeColor(mesh6, meshAlert6, false);
            }
            if (topic == "/UPS/shutdown")
            {
                if (value == "1")
                    ChangeColor(mesh7, meshAlert7, true);
                else
                    ChangeColor(mesh7, meshAlert7, false);
            }
            if (topic == "/UPS/beeper")
            {
                if (value == "1")
                    ChangeColor(mesh8, meshAlert8, true);
                else
                    ChangeColor(mesh8, meshAlert8, false);
            }

        }

        private void ChangeColor(GameObject meshObject, GameObject alertObject, bool alert)
        {
            if (alert)
            {
                alertObject.SetActive(true);
                meshObject.SetActive(false);
            }
            else
            {
                meshObject.SetActive(true);
                alertObject.SetActive(false);
            }
        }

        protected override void Update()
        {
            base.Update(); // call ProcessMqttEvents()

            if (eventMessages.Count > 0)
            {
                foreach(MqttMsgPublishEventArgs msg in eventMessages)
                {
                    UpdateValues(msg.Topic, System.Text.Encoding.UTF8.GetString(msg.Message));
                    Debug.Log("Test : " + System.Text.Encoding.UTF8.GetString(msg.Message));
                }
                eventMessages.Clear();
            }
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        private void OnValidate()
        {
            if (autoTest)
            {
                autoConnect = true;
            }
        }
    }
}
