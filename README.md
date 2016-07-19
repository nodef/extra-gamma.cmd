# ogamma

Get or set Gamma ramp for Display Device from Windows Console.


## usage

```batch
> ogamma [-r|--ramp] [-c|--color] [<values>]

:: [] -> optional argument
:: <> -> argument value
```

```batch
:: set gamma to 2
> ogamma 2

:: set gamma to default
> ogamma 1

:: set gamma for each color
> ogamma --color R 1.0 G 2.0 B 3.0

:: set gamma ramp (approx 2)
> ogamma --ramp 0.0 0.25 1.0

:: set gamma ramp to default
> ogamma --ramp 0.0 0.5 1.0

:: set gamma ramp to default
> ogamma --ramp 0.0 1.0

:: set gamma ramp for each color
> ogamma -r -c R 0.0 1.0 G 0.0 0.25 1.0 B 0.0 0.125 1.0

:: set gamma ramp for each color to default
> ogamma -r -c R 0.0 0.25 0.5 0.75 1.0 G 0.0 0.5 1.0 B 0.0 1.0

:: get current gamma ramp
> ogamma
```
