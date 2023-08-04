#### Описание
Рабочая сцена - `SampleScene`.\
Точка входа - объект `Bootstrapper`.\
В проекте не используется DI, поэтому все зависимости просто передаются в конструктор.

#### Окно калькулятора
Представляет `MainScreen`, в соответвующими Model, View, Presenter.

#### Логика калькулятора
Вычисления производятся наследниками `IMathOperationProcessor`. У каждого наследника имеется свой паттерн поиска операции. Например, для сложения (`AdditionProcessor`) - `([0-9]+)(\+)([0-9]+)$`. В дополнение к основной задаче реализован `SubtractionProcessor` для операция вычитания, но в программе не используется (Можно включить в классе `Bootstrapper`).

`EquationParser` парсит введеные пользователем данные. На основе используемых процессоров собирает один паттерн с именоваными группами. 

`CalculationService` сделан для настройки и расширения списка процессоров.

#### Сохранение состояния и истории
Сохраняется через `IMainScreenDataRepository`, использующий `IKeyValueStorage`.