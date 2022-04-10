echo off

echo hel lo c
echo parameter1 is  %1
set app_root=%cd%
echo app_root is  %app_root%
set ytd_root=%cd%\youtube-dl\
echo youtube_dl is in  %ytd_root%
set path=%path%;%ytd_root%
set ffmpeg_root=%cd%\ffmpeg\
set path=%path%;%ffmpeg_root%
set lists_outputdir=%cd%\output\playlists
echo playlists target %lists_outputdir%
youtube-dl %1 --config-location %ytd_root%\playlists_config.txt









