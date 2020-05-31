# WSL2 Upgrade

[![Status](https://img.shields.io/badge/Status-complete-1abc9c.svg)](https://github.com/abesuden/Tool-Belt/issues)
[![Creator](https://img.shields.io/badge/Creator-@Abesuden-informational.svg)](https://github.com/abesuden/Tool-Belt/contributors)

## Getting Started

First, make sure that the latest version of Windows 10 has been installed. Then there are two Windows features that need to be checked, so search for and then open the `Turn Windows features on or off` panel. At the bottom, both `Windows Subsystem For Linux` and `Virtual Machine Plateform` features must be turned on if not already. A complete restart is then required to apply the settings. Once done, use the following tool in any order desired:

```
listDistro.ps1
```
> [🔨](https://github.com/abesuden/Tool-Belt/WSL2-upgrade/listDistro.ps1) use to list current WSL distros and what version of WSL they are running in


```
setDistro.ps1
```
> [🔨](https://github.com/abesuden/Tool-Belt/WSL2-upgrade/setDistro.ps1) set the desired distro to either 1 for WSL or 2 for WSL2

```
setDefault.ps1
```
> [🔨](https://github.com/abesuden/Tool-Belt/WSL2-upgrade/setDefault.ps1) sets the default version of WSL to use when installing new distros

```
runDistro.ps1
```
> [🔨](https://github.com/abesuden/Tool-Belt/WSL2-upgrade/runDistro.ps1) a quick way to launch a WSL distro in PowerShell


### System Requirements

Operating System requirments:

```
Windows 10, Version 2004
```
> You will need to make sure you are on the latest version of Windows 10 in order to apply these tools. Update [here](ms-settings:windowsupdate)

## Creator Of Tools

* **Alex Besuden** - *Provided PS1 Files* - [@abesuden](https://github.com/abesuden)

## Acknowledgments

[Microsoft Developer Youtube Vid](https://youtu.be/MrZolfGm8Zk?t=501) - Explained how to upgrade to WSL2 and the associated PowerShell commands
