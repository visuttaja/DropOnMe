echo off

echo heL Lo c
echo parameter1 is  %1
set app_root=%cd%
echo app_root is  %app_root%
set ytd_root=%cd%\youtube-dl\
echo yt-dlp is in  %ytd_root%
set path=%path%;%ytd_root%
set ffmpeg_root=%cd%\ffmpeg\
set path=%path%;%ffmpeg_root%
set lists_outputdir=%cd%\output\playlists
echo playlists target %lists_outputdir%
rem youtube-dl %1 --config-location %ytd_root%\playlists_config.txt
rem next are all JSON
rem yt-dlp -j --flat-playlist %1 > flatListUris.log 
rem convert to list of urls

rem yt-dlp -j --flat-playlist %1 | jq -r ".url"> listUris.log 
echo UPDATING YT-DLP!
yt-dlp -U
start yt-dlp %1 --config-location playlists_config.txt








