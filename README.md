# ResumeBuilder

![.NET Core](https://img.shields.io/badge/.NET-8.0-blue) ![ASP.NET](https://img.shields.io/badge/ASP.NET-Core-informational) ![PdfSharp](https://img.shields.io/badge/PDFSharp-v1.50-brightgreen)

**ResumeBuilder** is a simple web application built with ASP.NET Core that allows users to generate a custom PDF resume (CV). The application collects various sections of a resume such as personal information, professional experience, education, and skills, and formats them into a downloadable PDF document.

## Features

- **PDF Resume Generation**: Dynamically generates a PDF document based on user input.
- **Multi-line text support**: Supports line wrapping in the PDF for long sections of text.
- **User-friendly interface**: Simple form-based UI for collecting CV information.
- **Customizable Sections**: Includes fields for personal details, experience, education, skills, languages, and more.
- **Basic Unit Tests**: Includes unit tests to validate the PDF generation process.

## Technologies Used

- **.NET 8.0**: The latest version of the .NET platform.
- **ASP.NET Core**: For building the web application.
- **PdfSharp**: A library for creating and manipulating PDF documents.
- **xUnit**: Unit testing framework.
  
## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (recommended)
- Any OS compatible with .NET Core (Windows, macOS, Linux)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/LOL-li-POP/ResumeBuilder.git
   cd ResumeBuilder
   ```

2. Open the project in your preferred IDE (e.g. Visual Studio or VS Code).

3. Restore the dependencies:

   ```bash
   dotnet restore
   ```

4. Build the project:

   ```bash
   dotnet build
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. The application should now be running at `http://localhost:5000` or a similar port depending on your configuration.

### Running Tests

Unit tests are available to validate the PDF generation. To run the tests, use the following command:

```bash
dotnet test
```

After the tests complete, the results will be displayed in the terminal.

## Usage

1. Navigate to the main page (`http://localhost:5000`).
2. Fill in the form fields with your personal and professional details.
3. After filling out the form, click the **Generate PDF** button.
4. A PDF file of your resume will be generated and downloaded to your device.

## Project Structure

```
ResumeBuilder/
│
├── Controllers/
│   └── HomeController.cs     # Main controller handling the PDF generation
├── Models/
│   └── CvModel.cs            # Data model representing the resume form
├── Utilities/
│   └── PdfWrapTextUtility.cs # Utility for handling multi-line text in the PDF
├── Views/
│   └── Home/
│       └── Index.cshtml      # The main view where users input resume data
├── wwwroot/                  # Static files (CSS, JS, etc.)
├── ResumeBuilder.Tests/       # Unit test project
├── Program.cs                # Entry point of the application
├── Startup.cs                # Configurations for the ASP.NET Core app
└── README.md                 # Project documentation
```

## Future Enhancements

- **User Authentication**: Allow users to save and retrieve resumes by creating an account.
- **Template Customization**: Provide more template options for different styles of resumes.
- **Localization**: Add support for multiple languages.
- **Cloud Storage**: Integrate cloud storage for saving resumes online.
  
## Contribution

Contributions are welcome! If you'd like to contribute to the project:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

---

### Additional Links:

- [PdfSharp Documentation](https://pdfsharp.net)
- [xUnit Documentation](https://xunit.net)
