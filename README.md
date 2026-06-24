# 💰 Expense Tracker

Менеджер расходов, написанный на WPF с использованием паттерна MVVM.

## 📋 Функционал

- ➕ Добавление расходов (название, сумма, категория)
- ❌ Удаление выбранного расхода
- 💾 Сохранение расходов в JSON файл
- 📂 Загрузка расходов из JSON файла
- 💵 Подсчёт общей суммы расходов

## 🏗️ Архитектура

Проект построен на паттерне **MVVM (Model-View-ViewModel)**:

- **Model** — `Expense.cs` — хранит данные одного расхода
- **ViewModel** — `MainViewModel.cs` — логика приложения
- **View** — `MainWindow.xaml` — интерфейс пользователя
- **Commands** — `RelayCommand.cs` — реализация команд

## 🛠️ Технологии

- C# / .NET Framework
- WPF (Windows Presentation Foundation)
- MVVM паттерн
- Newtonsoft.Json

## 🚀 Запуск

1. Скачай `setup.exe` из [Releases](https://github.com/Roma4ja/ExpenseTracker/releases)
2. Запусти установщик
3. Следуй инструкциям установки
4. Запускай приложение!
