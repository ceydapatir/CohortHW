using CohortHomework4;

PatientDiagnosis patient1 = new PatientDiagnosis("Batuhan Umut", -1);
PatientDiagnosis patient2 = new PatientDiagnosis("Ceylin Yılmaz", -1);

patient1.SeePatient();
patient2.SeePatient();

patient1.AnalysisResult(120);
patient2.AnalysisResult(90);

patient1.SeePatient();
patient2.SeePatient();