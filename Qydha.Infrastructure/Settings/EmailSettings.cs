﻿namespace Qydha.Infrastructure.Settings;

public class EmailSettings
{
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string ConfirmUrl { get; set; } = string.Empty;
    public string ConfirmEmailTemplate { get; } = @"
            <!DOCTYPE html>
            <html lang='en'>

            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>تاكيد البريد الالكتروني</title>
                <style>
                    @import url('https://fonts.googleapis.com/css2?family=IBM+Plex+Sans+Arabic&display=swap');

                    body {
                        font-family: 'IBM Plex Sans Arabic', sans-serif;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding: 0;
                    }

                    .container {
                        background-color: #fff;
                        max-width: 600px;
                        margin: 20px auto;
                        padding: 20px;
                        border-radius: 5px;
                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }

                    h1 {
                        color: #333;
                        text-align: center;
                    }

                    p {
                        color: #555;
                        text-align: center;
                    }

                    .btn-container {
                        text-align: center;
                        margin-top: 20px;
                    }

                    .btn {
                        display: inline-block;
                        background-color: #007BFF;
                        color: #fff;
                        padding: 10px 20px;
                        text-decoration: none;
                        border-radius: 5px;
                    }

                    .btn:hover {
                        background-color: #0056b3;
                    }
                </style>
            </head>

            <body>
                <div class='container'>
                    <h1>تأكيد البريد الالكتروني</h1>
                    <p> شكرا لاستخدامك تطبيق قيدها برجاء الضغط علي الزر ادناه لتاكيد البريد الالكتروني </p>

                    <div class='btn-container'>
                        <a href='[confirmLink]' class='btn'>تاكيد</a>
                    </div>
                </div>
            </body>

            </html>
    ";
}
