# OverlayWindow
Simple topmost semi-transparent window using MonoGame

## NuGet: https://www.nuget.org/packages/OverlayWindow/

[ChangeLog](docs/CHANGELOG.md)

## How To Use
Add a `MonoGame Windows Project`, and change the base class of your game from `OverlayGame`.

```cs
public class Game1 : OverlayGame
```

OverlayGame inherits from `Game` and it makes the window layered, transparent, top-most and unclickable.

It looks like a semi-transparent sticker on your screen, or even a HUD.

Drawing on the window looks like drawing directly on screen.

## Examples

See [OverlayWindow.Sample](OverlayWindow.Sample) for a fullscreen window that renders MonoGame's logo.

![demo](docs/demo.png)