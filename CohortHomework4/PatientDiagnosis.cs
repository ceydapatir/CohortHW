using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortHomework4
{
    public class PatientDiagnosis
    {
        private string? patientName;
        private static int id;
        private int patientId;
        private int bacteriaAmount;
        private static string patientCondition;
        private string? diagnosis;

        public string? PatientName { get => patientName; set => patientName = value; }
        public static int Id { get => id; }
        public int BacteriaAmount { get => bacteriaAmount; set => bacteriaAmount = value; }
        public static string PatientCondition { get => patientCondition; }
        public int PatientId { get => patientId; set => patientId = value; }
        public string? Diagnosis { get => diagnosis; set => diagnosis = value; }

        static PatientDiagnosis(){
            id = 0;
            patientCondition = "Undetermined";
        }

        public PatientDiagnosis(string patientName, int bacteriaAmount)
        {
            id++;
            PatientName = patientName;
            BacteriaAmount = bacteriaAmount;
            PatientId = id;
            Diagnosis = patientCondition;
        }

        enum DiagnosisType{
            Healthy = 103,
            SIBO = 120,
            IBS
        }

        public void AnalysisResult(int result){
            BacteriaAmount = result;
            if(BacteriaAmount <= (int)DiagnosisType.Healthy){
                Diagnosis = "Negative / " + DiagnosisType.Healthy.ToString();
            }else if(BacteriaAmount <= (int)DiagnosisType.SIBO){
                Diagnosis = "Positive / " + DiagnosisType.SIBO.ToString();
            }else{
                Diagnosis = "Positive / " + DiagnosisType.IBS.ToString();
            }
        }

        public void SeePatient(){
            Console.WriteLine("------------------------");
            Console.WriteLine("Patient Name: " + PatientName);
            Console.WriteLine("Patient Id: " + PatientId);
            Console.WriteLine("Patient Bacterial Amount: " + BacteriaAmount);
            Console.WriteLine("Patient Diagnosis: " + Diagnosis);
        }
    }
}