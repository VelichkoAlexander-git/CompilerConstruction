## 1. Регулярное выражение для решения предположенной задачи.

`^(([+][0-9][0-9][0-9]|0)\s?\(([0-9][0-9][0-9])\)\s?)?(\d\s?\d\s?\d\s?\d\s?\d)$`

## 2. Построить конечный автомат, реализующий анализатор, при необходимости преобразовать его детерминированному виду.

![](https://github.com/VelichkoAlexander-git/CompilerConstruction/blob/master/LabWorkFiniteStateMachine/image.jpg "Детерминированный вид")

## 3. Записать таблицу состояний автомата

|   | 0    | +373 | 1..9 |space |  (   |  )   |
|:-:|:----:|:----:|:----:|:----:|:----:|:----:|
| 0 |   1  |   1  |   7  | ERR  | ERR  | ERR  |
| 1 | ERR  | ERR  | ERR  |   1  |   2  | ERR  |
| 2 | ERR  | ERR  |   3  | ERR  | ERR  | ERR  |
| 3 |   4  | ERR  |   4  | ERR  | ERR  | ERR  |
| 4 |   5  | ERR  |   5  | ERR  | ERR  | ERR  |
| 5 | ERR  | ERR  | ERR  | ERR  | ERR  |   6  |
| 6 | ERR  | ERR  |   7  |   6  | ERR  | ERR  |
| 7 |   8  | ERR  |   8  |   7  | ERR  | ERR  |
| 8 |   9  | ERR  |   9  |   8  | ERR  | ERR  |
| 9 |  10  | ERR  |  10  |   9  | ERR  | ERR  |
|10 |  11  | ERR  |  11  |  10  | ERR  | ERR  |
|11 |  -   |  -   |  -   |  -   |  -   |  -   |
|ERR|  -   |  -   |  -   |  -   |  -   |  -   |
