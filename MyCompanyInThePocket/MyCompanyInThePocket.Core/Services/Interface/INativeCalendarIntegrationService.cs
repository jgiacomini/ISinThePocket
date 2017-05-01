﻿using MyCompanyInThePocket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyInThePocket.Core.Services.Interface
{
    public interface INativeCalendarIntegrationService
    {
        Task PushMeetingsToCalendarAsync(List<Meeting> meetings);
        Task DeleteCalendarAsync();
    }
}
