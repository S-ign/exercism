public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] bytes = new byte[8];
        for (int i = 0; i < 8; i++) {
            bytes[i] = (byte)((reading >> (8 * i)) & 0xFF);
        } 
        return bytes;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return 039489238L;
    }
}
