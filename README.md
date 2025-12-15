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

### How to Use This Project  

#### Setup  
- Install .NET 6 SDK  
- Clone the repository  
- Open in Visual Studio or use `dotnet run`  

#### Importing Samples  
- Click **"Import Samples"**  
- Select a directory containing malware samples  
- Enter a category (e.g., `"Ransomware"`, `"Trojan"`)  
- Samples will be hashed and stored in the database  

#### Scanning  
- Select samples to scan (or leave all unselected to scan all)  
- Enter the antivirus product name  
- Click **"Scan Selected Samples"**  
- The application will simulate scanning using the EICAR test file  

#### Reporting  
- Click **"Generate HTML Report"**  
- Choose a location to save the report  
- The report will show detection rates and scan results  

### Important Notes  
- **Safety**: This application uses the EICAR test file for demonstration purposes. In a real implementation, you would handle actual malware samples with extreme caution in an isolated environment.  
- **Database**: The application uses SQLite for storage. The database file (`avtest.db`) will be created in the application directory.  
- **Scanning Simulation**: The current scan engine simulates detection by checking for the EICAR string. To integrate with real antivirus products, you would need to implement specific APIs or command-line interfaces.  
- **Threading**: Long-running operations (import, scan) are executed on background threads to keep the UI responsive.  

This project provides a complete framework for testing antivirus detection capabilities against a dataset of malware samples, with a user-friendly interface and reporting features.

---

## 中文

### 概述  
**AVDetectionTest-Dataset** 是一个完整的 C# Windows Forms 应用程序，用于通过可自定义的恶意软件样本数据集评估杀毒软件的检出能力。适用于安全研究人员、红队人员、教师和学生：

- 按类别导入并管理测试文件（如 EICAR）  
- 在安全可控的环境中模拟杀毒扫描  
- 将扫描结果记录到本地 SQLite 数据库  
- 生成包含检出率统计的可视化 HTML 报告  

> ⚠️ **注意**：本工具使用 **EICAR 测试文件**——这是一个被所有杀毒软件识别为测试签名的安全、无害字符串。**不包含也不执行任何真实恶意软件。**

### 背景意义  
正如文章《[杀毒软件对比：检出率与算法（2026）](https://data-encoder.com/antivirus-comparison-detection-rates-and-algorithms/)》所述，即使是 Windows Defender 和 360 Total Security 等主流杀软，也可能因代码混淆、加密或 FUD（完全无感）技术而被绕过。本工具帮助您以**可重复、合乎伦理的方式**实证测试杀软的检测行为。

### 如何使用本项目  

#### 环境设置  
- 安装 .NET 6 SDK  
- 克隆本仓库  
- 在 Visual Studio 中打开，或使用命令 `dotnet run` 运行  

#### 导入样本  
- 点击 **“导入样本”**  
- 选择包含恶意软件样本的文件夹  
- 输入类别（例如 `"勒索软件"`、`"木马"`）  
- 样本将被计算哈希值并存入数据库  

#### 扫描测试  
- 勾选要扫描的样本（若不勾选，则默认扫描全部）  
- 输入杀毒软件名称  
- 点击 **“扫描选中样本”**  
- 应用程序将使用 EICAR 测试文件模拟扫描过程  

#### 生成报告  
- 点击 **“生成 HTML 报告”**  
- 选择报告保存位置  
- 报告将展示检出率和详细扫描结果  

### 重要说明  
- **安全性**：本应用仅使用 EICAR 测试文件用于演示。在真实场景中，处理实际恶意样本必须在严格隔离的环境中进行，并采取极端谨慎措施。  
- **数据库**：应用程序使用 SQLite 存储数据，数据库文件（`avtest.db`）将自动创建在程序目录中。  
- **扫描模拟**：当前扫描引擎通过检测 EICAR 字符串来模拟杀毒行为。若需对接真实杀毒软件，需另行实现其 API 或命令行接口。  
- **多线程**：耗时操作（如导入、扫描）在后台线程执行，以确保界面响应流畅。  

本项目提供了一套完整的框架，可用于测试杀毒软件对恶意样本数据集的检测能力，并配备用户友好的界面和报告生成功能。

---

> ✨ **Ethical Use Only** | 仅限合法授权测试  
> 🌐 Inspired by real AV evaluation research: [data-encoder.com](https://data-encoder.com/antivirus-comparison-detection-rates-and-algorithms/)
