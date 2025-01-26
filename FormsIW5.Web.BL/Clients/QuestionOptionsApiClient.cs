﻿namespace FormsIW5.Web.BL;

public partial class QuestionOptionsApiClient
{
    public HttpClient HttpClient
    {
        get { return _httpClient; }
        set { 
            _httpClient = value;
            Initialize();
        }
    }

    partial void Initialize()
    {
        BaseUrl = _httpClient?.BaseAddress?.ToString();
    }
}
