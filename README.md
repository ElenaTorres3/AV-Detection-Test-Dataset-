# AV-Detection-Test-Dataset-
 A complete C# Windows desktop application for testing antivirus detection rates using a customizable malware sample dataset. Includes dataset management, simulated scanning, SQLite storage, and HTML reporting. Safe testing with EICAR standard.  
 一个完整的 C# Windows 桌面应用程序，用于使用可自定义的恶意软件样本数据集测试杀毒软件的检出率。包含样本管理、模拟扫描、SQLite 存储和 HTML 报告功能。使用 EICAR 标准进行安全测试。

 # AVDetectionTest-Dataset  
[![.NET](https://img.shields.io/badge/.NET-6.0-blue)](https://dotnet.microsoft.com/)  
[English](#english) | [中文](#中文)

> 🔍 **Inspired by real-world AV evaluation practices** — Learn more in the in-depth analysis:  
> [Antivirus Comparison: Detection Rates and Algorithms (2026)](https://data-encoder.com/antivirus-comparison-detection-rates-and-algorithms/)

---

## English

### Overview  
**AVDetectionTest-Dataset** is a complete C# Windows Forms application designed to evaluate antivirus detection capabilities using a customizable dataset of malware samples. It helps security researchers, red teamers, educators, and students:

- Import and manage malware-like test files (e.g., EICAR) by category  
- Simulate antivirus scans in a safe, controlled environment  
- Log detection results in a local SQLite database  
- Generate visual HTML reports with detection statistics  

> ⚠️ **Note**: This tool uses the **EICAR test file**—a safe, industry-standard string recognized by all antivirus engines as a non-malicious test signature. **No real malware is included or executed.**

### Why This Matters  
As highlighted in [Antivirus Comparison: Detection Rates and Algorithms (2026)](https://data-encoder.com/antivirus-comparison-detection-rates-and-algorithms/), even top-tier AVs like Windows Defender and 360 Total Security can be bypassed through obfuscation, encryption, and FUD (Fully Undetectable) techniques. This tool helps you **empirically test detection behavior** in a repeatable, ethical way.

### Features  
- 📂 Import test samples from local folders  
- 🏷️ Organize by threat category (e.g., Trojan, Ransomware, Test)  
- ⚡ Simulated scanning engine (EICAR-based detection logic)  
- 📊 Automatic logging of scan results (AV name, detection status, time)  
- 📄 One-click HTML report generation  
- 💾 Local SQLite database (no cloud dependencies)  

### Requirements  
- Windows 10 or 11  
- .NET 6.0 Runtime (or SDK for development)

### Quick Start  
```bash
git clone https://github.com/ElenaTorres3/AV-Detection-Test-Dataset-.git
cd AVDetectionTest-Dataset
dotnet run
