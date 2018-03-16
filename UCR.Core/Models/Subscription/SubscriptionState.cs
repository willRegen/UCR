﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HidWizards.UCR.Core.Models.Subscription
{
    public class SubscriptionState
    {
        public Guid StateGuid { get; }
        public Profile ActiveProfile { get; }
        public bool IsActive { get; set; }

        public List<DeviceSubscription> DeviceSubscriptions { get; }
        public Dictionary<string, List<DeviceBindingSubscription>> DeviceBindingSubscriptions { get; }
        public Dictionary<string, List<DeviceBindingSubscription>> OutputDeviceBindingSubscriptions { get; }
        public List<Plugin> ActivePlugins { get; }

        public SubscriptionState(Profile profile)
        {
            StateGuid = Guid.NewGuid();
            ActiveProfile = profile;
            DeviceSubscriptions = new List<DeviceSubscription>();
            DeviceBindingSubscriptions = new Dictionary<string, List<DeviceBindingSubscription>>();
            OutputDeviceBindingSubscriptions = new Dictionary<string, List<DeviceBindingSubscription>>();
            ActivePlugins = new List<Plugin>();
            IsActive = false;
        }

        public void AddOutputDevice(Device device, Profile profile)
        {
            DeviceSubscriptions.Add(new DeviceSubscription(device, profile));
        }

        public void AddDeviceBindingSubscriptions(Plugin plugin)
        {
            AddDeviceBindingSubscriptions(plugin, DeviceIoType.Input);
            AddDeviceBindingSubscriptions(plugin, DeviceIoType.Output);
        }

        // TODO
        private void AddDeviceBindingSubscriptions(Plugin plugin, DeviceIoType deviceIoType)
        {
            //var deviceBindings = deviceIoType == DeviceIoType.Input ? plugin.GetInputs() : plugin.Outputs;
            //var deviceBindingsList = deviceIoType == DeviceIoType.Input ? DeviceBindingSubscriptions : OutputDeviceBindingSubscriptions;
            //if (deviceBindingsList.ContainsKey(plugin.Title))
            //{
            //    foreach (var deviceBindingSubscription in deviceBindingsList[plugin.Title])
            //    {
            //        deviceBindingSubscription.IsOverwritten = true;
            //    }
            //    deviceBindingsList[plugin.Title].AddRange(DeviceBindingSubscription.GetSubscriptionsFromList(deviceBindings, StateGuid, DeviceSubscriptions));
            //}
            //else
            //{
            //    deviceBindingsList[plugin.Title] = DeviceBindingSubscription.GetSubscriptionsFromList(deviceBindings, StateGuid, DeviceSubscriptions);
            //}
        }

        public void BuildActivePluginsList()
        {
            foreach (var subscription in DeviceBindingSubscriptions)
            {
                // TODO
                //ActivePlugins.Add(subscription.Value.First(d => d.IsOverwritten == false).DeviceBinding.Plugin);
            }
        }
    }
}
