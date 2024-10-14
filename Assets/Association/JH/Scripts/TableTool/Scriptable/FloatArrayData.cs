namespace GachaAddactiveFuncset
{
    public static class FloatArrayData
    {
        static public float[] GetNormalizeForm(this float[] TargetData)
        {
            if (TargetData == null || TargetData.Length == 0 || TargetData[0] == 0)
            {
                return null;
            }
            int length = TargetData.Length;
            float sum = 0f;

            float[] NormalizeForm = new float[TargetData.Length];

            for (int i = 0; i < length; i++)
            {
                NormalizeForm[i] = TargetData[i];
                sum += TargetData[i];
            }


            for (int i = 0; i < length; i++)
            {
                NormalizeForm[i] /= sum;
            }

            return NormalizeForm;
        }

        static public float[] GetSnowballForm(this float[] TargetData)
        {
            if (TargetData == null || TargetData.Length == 0 || TargetData[0] == 0)
            {
                return null;
            }
            int length = TargetData.Length;
            float sum = 0f;

            float[] SnowballForm = new float[TargetData.Length];

            for (int i = 0; i < length; i++)
            {
                sum += TargetData[i];
                SnowballForm[i] = sum;
            }


            for (int i = 0; i < length; i++)
            {
                SnowballForm[i] /= sum;
            }

            return SnowballForm;
        }
    }
}

