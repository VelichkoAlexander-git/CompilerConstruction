Конструирование компиляторов
======

### Задания

**[1. Regex](#1-regex)**<br>
**[2. Интерпретатор языка ассемблера](#2-интерпретатор-языка-ассемблера)**<br>
**[3. Автоматные грамматики](#3-автоматные-грамматики)**<br>
**[4. Анализатор многочленов и семантические процедуры](#4-анализатор-многочленов-и-симантические-процедуры)**<br>

***

## 1. Regex

### 1. (Count) Написать функцию, которая определяет количество входящих в заданную строку почтовых индексов (почтовый индекс состоит из 6 цифр).

### 2. (Regex.Replace) Дана строка — предложение на русском языке. Поменять местами первую и последнюю буквы каждого слова.

### 3. Дана строка. Посчитать, сколько смайликов в ней содержится. Смайликом будем считать последовательность символов, удовлетворяющую условиям:  
  - первым символом является либо `;` (точка с запятой) либо `:` (двоеточие) ровно один раз
  - далее может идти символ `-` (минус) сколько угодно раз (в том числе символ минус может идти ноль раз)
  - в конце обязательно идет некоторое количество (не меньше одной) одинаковых скобок из следующего набора: `(`, `)`, `[`, `]`

  - o	внутри смайлика не может встречаться никаких других символов.

## 2. Интерпретатор языка ассемблера

### Требуется написать программу, которая принимает на входе текстовый файл с программой на языке ассемблера для некоторой виртуальной машины и покомандно выполняет её.

  * Машина содержит 16 однобайтовых регистров с именами `r0`, `r1`, ..., `r15`.
  * Текст программы может содержать метки в формате «`метка:`».
  * Арифметические операции реализованы как обычная однобайтовая арифметика. Например, 255+1 даст в результате 0.  
  * Распознавать команды удобно с помощью регулярных выражений. Они позволяют сразу как «узнать» команду, так и извлечь её параметры.  
  * Команды можно хранить в списке.  
  * Значения регистров удобно хранить в словаре, где ключи - их имена.  
  * Метки хранятся в отдельном словаре: ключ - имя метки, значение - номер команды. При условном или безусловном переходе на метку, счетчик команд просто изменяется на номер команды, на которую происходит переход.
  
#### Список команд:

  1. `LD регистр, #число` - загрузить однобайтовое (0..255) число в указанный регистр.
  2. `MOV приёмник, источник` - копирует значение из одного регистра в другой.
  3. `ADD приёмник, источник` - добавляет к регистру-приёмнику значение регистра-источника.
  4. `SUB приёмник, источник` - вычитает из регистра-приёмника значение регистра-источника.
  5. `BR метка` - безусловный переход на метку.
  6. `BRGZ метка, регистр` - переход на метку, если значение указанного регистра больше нуля.
  
  ## 3. Автоматные грамматики
  
  ### Класс распозноваемых цепочек - телефонные номера ПМР (упрощенный вариант).
  
  Возможны следующие варианты записи телефонного номера:
  * номер
  * 0(код)номер
  * +373(код)номер

«`номер`» - это всегда пять цифр, возможно разделённых пробелами.  
«`код`» - всегда три цифры.

Перед скобками и после них также могут быть пробелы.  
Примеры верных цепочек: «`+373(777)12344`», «`0 (533) 43210`», «`5 43 21`».

## 4. Анализатор многочленов и симантические процедуры

### Задача из книги: `Свердлов С.З. "Конструирование компиляторов."`

### Пользуясь методом рекурсивного спуска, запрограммируем синтаксический анализатор многочленов, правила записи которых определены диаграммами. Будем считать, что анализатор должен просто отвечать на вопрос, является ли введенная пользователем строка правильно записанным многочленом.

### Анализатор многочленов

![2 22](https://user-images.githubusercontent.com/70848654/114620381-d44ba500-9cab-11eb-8705-f3bbb59cfcbf.png)

![2 23](https://user-images.githubusercontent.com/70848654/114620384-d4e43b80-9cab-11eb-8c1d-5ed2808a5157.png)

![2 24](https://user-images.githubusercontent.com/70848654/114620385-d4e43b80-9cab-11eb-9897-b43f1b68b760.png)

### Cимантические процедуры

![2 31](https://user-images.githubusercontent.com/70848654/114911923-b7d07980-9e1f-11eb-90a7-246c35022650.png)

![2 32](https://user-images.githubusercontent.com/70848654/114911928-b8691000-9e1f-11eb-8859-00d032473135.png)

![2 33](https://user-images.githubusercontent.com/70848654/114912502-59f06180-9e20-11eb-9220-53219f152bc2.png)
