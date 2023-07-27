﻿using System;
using System.Collections.Generic;

namespace employee_webapi_EF_.Models.EF;

public partial class EmployeeDetail
{
    public int EmpNo { get; set; }

    public string? EmpName { get; set; }

    public string? EmpDesignation { get; set; }

    public int? EmpSalary { get; set; }

    public bool? EmpIsPermenant { get; set; }

    public int? EmpDeptno { get; set; }
}
