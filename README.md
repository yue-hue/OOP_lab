# OOP_lab
BSUIR, OOP labs, 4th semester

1. Ознакомление с концепциями ООП: наследование и полиморфизм типов (виртуальные методы)
Построить иерархию классов для вывода графических фигур: отрезок, прямоугольник, эллипс и т.д. - не менее 6 фигур.
Распределить классы по модулям. Создать список фигур в виде отдельного класса.
В главном модуле программы добавить в список различные фигуры (статическая инициализация), после чего запустить рисование списка фигур.
Выполнить задание на языке C++/C#.
Для рисования использовать любую подходящую графическую библиотеку.

2. Графический редактор
Расширить пример с графическими фигурами так, чтобы фигуры можно было создавать на уровне пользовательского интерфейса.
Существуют несколько способов: ввод координат с помощью мыши, диалоговый ввод значений, ввод на скриптовом языке. Студент может выбрать любой способ ввода.
Создание объекта должно выполняться так, чтобы добавление нового класса в систему не требовало изменения существующего кода (выбор типа с помощью оператора case/switch и множественного if делать нельзя).
Классы фигур не должны содержать метод рисования.
Получившаяся программа должна представлять собой примитивный графический редактор.

3. Сериализация объектов
Реализовать сериализацию/десериализацию объектов из существующей иерархии классов в файл/из файла, формат сериализации определяется индивидуальным вариантом.
В пользовательском интерфейсе необходимо реализовать следующие функции:
Возможность изменять свойства объектов (редактирование).
Добавлять/удалять объекты из списка.
Сериализация/десериализация списка объектов.
Добавление новых классов в иерархию не должно приводить к необходимости переписать существующий код, не использовать if-else/switch, рефлексию.

Binary

4. Плагины - иерархия
Расширить имеющуюся иерархию новыми классами с помощью динамической загрузки модуля (плагина).
Новые модули должны добавлять или расширять функциональность базовой программы: новый класс в иерархии, функции по работе с ним, новые элементы в пользовательском интерфейсе для работы с новым классом.
Загружать модули можно из папки либо посредством строки-параметра в главном модуле с именем нового модуля и возможной перекомпиляцией. В идеале добавление нового модуля должно выполняться его динамической загрузкой, т.е. вообще не должно требовать изменения кода программы.
Разработать механизм подписывания плагинов.
Сделать подпись плагина с последующей проверкой базовой программой данной подписи на достоверность (время активации и целостность).

5. Плагины - функциональность
На базе предыдущей лабораторной работы (№4) на основе плагинов (2-3 плагина) реализовать возможность обработки структур перед сохранением в файл и после загрузки из файла.
Тип обработки задаётся вариантом.
Дополнительная функциональность должна находиться в меню настроек и зависеть от загруженных плагинов. Загрузка плагинов производится автоматически из папки, либо выбором файла с плагином через пользовательский интерфейс.
Предусмотреть дополнительную настройку функциональности плагина в меню настройки плагинов. Например, заданием параметров шифрования/архивации, выбор алгоритма шифрования, дополнительные правила трансформации, кодировки и т.д.

Архивация

6. Паттерны
На базе предыдущей лабораторной работы (№5) обменяться с товарищем функциональными плагинами (минимум одним) и адаптировать их в этой же работе с помощью паттерна Адаптер (т.е. появятся новые функции от плагина товарища, загруженные через плагин с адаптером).
