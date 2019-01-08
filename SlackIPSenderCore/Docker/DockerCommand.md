This idea come from this post by [Scott Hanselman](https://www.hanselman.com/blog/BuildingRunningAndTestingNETCoreAndASPNETCore21InDockerOnARaspberryPiARM32.aspx) then I add my command that I need to remember cause it was done with some trial and error and I did not want to loose all those command.

**Download image and running dotnet --info**
```
pi@raspberrypi:~ $ docker run --rm -it microsoft/dotnet:2.1-runtime dotnet --info
```
**Is Equal because docker is multi-arch so on download it know from what architecture is running from.**
```
pi@raspberrypi:~ $ docker run --rm -it microsoft/dotnet:2.1-runtime-stretch-slim-arm32v7 dotnet --info
```
**To Remove am image base on a TAG**
```
pi@raspberrypi:~ $ docker images -a
REPOSITORY          TAG                                IMAGE ID            CREATED             SIZE
microsoft/dotnet    2.1-sdk                            8c0431f30a5d        2 weeks ago         1.58GB
microsoft/dotnet    2.1-runtime                        813c9f82f99c        2 weeks ago         154MB
microsoft/dotnet    2.1-runtime-stretch-slim-arm32v7   813c9f82f99c        2 weeks ago         154MB

pi@raspberrypi:~ $ docker rmi microsoft/dotnet:2.1-runtime-stretch-slim-arm32v7
```
**To Remove am image base on a ID
Caution it Remove all images**
```
pi@raspberrypi:~ $ docker rmi 813c9f82f99c
```
**Build your images
Base on my Dockerfile I take image 2.1-runtime**
```
pi@raspberrypi:~ $ docker build -f Dockerfile_run -t slackipsendercore_run .
```

*You can see my Dockerfile here: [slackipsendercore_run](https://github.com/aleblanc70/SlackIPSenderCore/blob/http/SlackIPSenderCore/Dockerfile_run)*

**Build within the SDK image and you can put more stuff like your unittest etc...**
```
pi@raspberrypi:~ $ docker build -f Dockerfile_sdk -t slackipsendercore_sdk .
```

*You can see my Dockerfile here: [slackipsendercore_sdk](https://github.com/aleblanc70/SlackIPSenderCore/blob/http/SlackIPSenderCore/Dockerfile_sdk)*

**Run with your newly create image**
```
pi@raspberrypi:~ $ docker run --rm slackipsendercore_run
or
pi@raspberrypi:~ $ docker run --rm slackipsendercore_sdk
```
