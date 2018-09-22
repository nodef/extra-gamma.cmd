Get or set Gamma ramp for Display Device from Windows Console.
> 1. Download [exe file](https://github.com/cmdf/extra-gamma/releases/download/1.0.0/egamma.exe).
> 2. Copy to `C:\Program_Files\Scripts`.
> 3. Add `C:\Program_Files\Scripts` to `PATH` environment variable.


```batch
> egamma [-r|--ramp] [-c|--color] [<values>]

:: [] -> optional argument
:: <> -> argument value
```

```batch
:: set gamma to 2
> egamma 2

:: set gamma to default
> egamma 1

:: set gamma for each color
> egamma --color R 1.0 G 2.0 B 3.0

:: set gamma ramp (approx 2)
> egamma --ramp 0.0 0.25 1.0

:: set gamma ramp to default
> egamma --ramp 0.0 0.5 1.0

:: set gamma ramp to default
> egamma --ramp 0.0 1.0

:: set gamma ramp for each color
> egamma -r -c R 0.0 1.0 G 0.0 0.25 1.0 B 0.0 0.125 1.0

:: set gamma ramp for each color to default
> egamma -rc R 0.0 0.25 0.5 0.75 1.0 G 0.0 0.5 1.0 B 0.0 1.0

:: get current gamma ramp
> egamma
```


[![cmdf](https://i.imgur.com/b5zPANh.jpg)](https://cmdf.github.io)
