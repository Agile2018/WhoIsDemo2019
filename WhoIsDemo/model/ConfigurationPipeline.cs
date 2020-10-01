namespace WhoIsDemo.model
{
    public class ConfigurationPipeline
    {
        
        public string configurationFaceProcessing { get; set; }
        public ParamsFaceProcessing paramsFaceProcessing { get; set; }
        public string configurationTrackingProcessing { get; set; }
        public ParamsTrackingProcessing paramsTrackingProcessing { get; set; }
        public string configurationEnrollmentProcessing { get; set; }
        public ParamsEnrollmentProcessing paramsEnrollmentProcessing { get; set; }
        public string configurationFlowVideo { get; set; }
        public ParamsFlow paramsFlow { get; set; }

    }
}
