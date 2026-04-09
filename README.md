# API Automation Framework (C#)

## Overview

This project is a **REST API automation framework** built using **C# and .NET**.
It demonstrates end-to-end API testing including **CRUD operations, logging, reporting, and validations**.

---

## Tech Stack

* C#
* .NET 8
* HttpClient
* NUnit
* Serilog (Logging)
* ExtentReports (Reporting)

---

## Project Structure

```
ApiFramework/
│── Config/              # App settings
│── Core/                # API client logic
│── Helpers/             # JSON utilities
│── Models/              # Request/Response models
│── Tests/               # Test cases
│── Utilities/           # Logger, Report Manager
│── Reports/             # HTML reports
│── logs/                # Log files
```

---

## Features

*  CRUD API Testing (POST, GET, PUT, DELETE)
* Strong Assertions (Status + Response Validation)
* Logging using Serilog
* HTML Reporting using ExtentReports
* Config-driven setup
* Clean and scalable structure

---

## Sample Test Scenario

* Create a new post using POST API
* Validate response status and data
* Log request & response
* Generate execution report

---

## How to Run

1. Clone the repository
2. Open in Visual Studio
3. Build the project
4. Run tests via Test Explorer

---

## Reports & Logs

* Reports → `Reports/report.html`
* Logs → `logs/log.txt`

---

## Key Learnings

* API testing using HttpClient
* JSON parsing & validation
* Framework design basics
* Logging & reporting integration

---

## Author

**Bhavya R**
**Bhavyagowda.rc@gmail.com**
---

## Note

This project is built for learning and demonstrating **SDET / QA Automation skills**.
