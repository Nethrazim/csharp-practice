using System;
using System.Threading;

namespace CSharpPractice.LanguageConcepts
{
    public class AlarmSystem
    {
        public event EventHandler AlarmTriggered;

        public void TriggerAlarm()
        {
            Console.WriteLine("AlarmSystem: Alarm triggered!");
            OnAlarmTriggered();
        }

        protected virtual void OnAlarmTriggered()
        {
            AlarmTriggered?.Invoke(this, EventArgs.Empty);
        }
    }
    public class FireDepartment
    {
        public void OnAlarmTriggered(object sender, EventArgs e)
        {
            Console.WriteLine("FireDepartment: Responding to the alarm!");
        }
    }
    public class PoliceDepartment
    {
        public void OnAlarmTriggered(object sender, EventArgs e)
        {
            Console.WriteLine("PoliceDepartment: Responding to the alarm!");
        }
    }
    public class MedicalServices
    {
        public void OnAlarmTriggered(object sender, EventArgs e)
        {
            Console.WriteLine("MedicalServices: Responding to the alarm!");
        }
    }

    class Events
    {
        public static void TestMulticastDelegates()
        {
            // Create the publisher
            var alarmSystem = new AlarmSystem();

            // Create the subscribers
            var fireDepartment = new FireDepartment();
            var policeDepartment = new PoliceDepartment();
            var medicalServices = new MedicalServices();

            // Subscribe to the event
            alarmSystem.AlarmTriggered += fireDepartment.OnAlarmTriggered;
            alarmSystem.AlarmTriggered += policeDepartment.OnAlarmTriggered;
            alarmSystem.AlarmTriggered += medicalServices.OnAlarmTriggered;

            // Trigger the alarm
            alarmSystem.TriggerAlarm();

            Console.WriteLine();

            // Unsubscribe one handler
            alarmSystem.AlarmTriggered -= policeDepartment.OnAlarmTriggered;

            // Trigger the alarm again
            alarmSystem.TriggerAlarm();
        }
    }
}
