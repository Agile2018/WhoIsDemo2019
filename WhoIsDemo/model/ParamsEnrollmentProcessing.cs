namespace WhoIsDemo.model
{
    public class ParamsEnrollmentProcessing
    {
        public int CFG_BEST_CANDIDATES_COUNT { get; set; }
        public int CFG_SIMILARITY_THRESHOLD { get; set; }
        public int CFG_IDENTIFICATION_SPEED { get; set; }
        public int CFG_IFACE_DETECT_FORCED { get; set; }
        public int CFG_IFACE_IGNORE_MULTIPLE_FACES { get; set; }
        public int CFG_IFACE_DETECTION_MODE { get; set; }
        public int CFG_IFACE_EXTRACTION_MODE { get; set; }
        public int CFG_IFACE_DETECTION_THRESHOLD { get; set; }
        public int AFACE_PARAMETER_SCORE_MIN { get; set; }
        public int AFACE_PARAMETER_SCORE_MAX { get; set; }
        public int AFACE_PARAMETER_ENROLL { get; set; }
        /// <summary>
        /// CHANGE PARAMETERS NEWS
        /// </summary>
        public int CFG_SIMILARITY_THRESHOLD_DEDUPLICATION { get; set; }
        public int AFACE_PARAMETER_DEDUPLICATION { get; set; }
        public int AFACE_PARAMETER_CONCATENATE_TEMPLATES { get; set; }
        public int AFACE_PARAMETER_MAXIMUM_TEMPLATES { get; set; }
        public int AFACE_PARAMETER_CONCATENATION_MODE { get; set; }
        public int AFACE_PARAMETER_VERIFICATION_SCORE { get; set; }

    }
}
