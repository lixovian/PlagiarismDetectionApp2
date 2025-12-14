# PlagiarismDetectionApp2
KPO - hometask 3

Простите, что код не в src - в райдере по умолчанию проекты очень не любят физические папки, которые делают так, что проекты лежат не в одной директории с солюшном. В райдере должны по идее отображаться Solution Folders для каждого микросервиса, но возможно и нет - тогда все проекты микросервисов будут отображаться в IDE в одной папке - это просто ошибка экспорта райдера, а не моя.

Реализованы все нужные функции, в том числе связь с облаком слов.

Для того, чтобы запустить приложение требуется сначала запустить сервис миграции для создания таблиц, а потом уже непосредственно Docker Compose.

Запуск приложения:
* dotnet ef migrations add InitialCreate -p FileStoringService.Infrastructure/FileStoringService.Infrastructure.csproj -s FileStoringService.Host/FileStoringService.Host.csproj
* dotnet ef migrations add InitialCreate -p FileAnalysisService.Infrastructure/FileAnalysisService.Infrastructure.csproj -s FileAnalysisService.Host/FileAnalysisService.Host.csproj
* docker compose up --build

В приложении используется DpendencyInjection, правильная слоистая архитектура на 5 слоях для каждого микросервиса, паттерны проектирования.

Плагиат определяется через сравнение вычисляемых автоматически SHA256-хешей текстов. Если есть кто-то, кто загрузил раньше такую же работу, то новая работа будет считаться спиисанной. В приложении есть 3 API. File Storing API отвечает за хранение и выдачу файлов/посылок. File Analysis API отвечает за формирование отчетов о списывании работ (в том числе часть с преподавтаелем).

Конкретная документация запросов прописана в описании Swagger.

Для подключения к Swagger используйте порты 5002 (gateway) или 5000, 5001 (остальные API).
