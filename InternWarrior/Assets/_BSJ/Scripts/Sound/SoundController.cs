public static class SoundController
{
    /// <summary>
    /// 배경음을 실행하는 메서드
    /// </summary>
    /// <param name="soundName">배경음 이름</param>
    public static void PlayBGMSound(string soundName)
    {
        if (SoundManager.Instance == null) return;

        // 배경음 재생
        SoundManager.Instance.PlayMusic(soundName);
    }

    /// <summary>
    /// 사운드를 실행하는 메서드
    /// </summary>
    /// <param name="soundName">사운드 이름</param>
    public static void PlaySFXSound(string soundName)
    {
        if (SoundManager.Instance == null) return;

        // 효과음 재생
        SoundManager.Instance.PlaySFX(soundName);
    }
}
