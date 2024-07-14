var reportButtonsId = [];

function createReportsButtons() {
    var reportsContainer = document.getElementById("stiReportsContainer");

    var allReports = [
        {
            category: "Get Started Dashboards",
            reports: {
                "DashboardChristmas": "Christmas",
                "DashboardTrafficAnalytics": "Traffic Analytics",
                "DashboardSalesPerfomance": "Sales Performance",
                "DashboardSalesStatistics": "Sales Statistics",
                "DashboardTicketsStatistics": "Tickets Statistics",
                "DashboardProducts": "Products"
            }
        },
        {
            category: "Miscellaneous Dashboards",
            reports: {
                "DashboardFastFoodLunch": "Fast Food Lunch",
                "DashboardNascar": "Nascar",
                "DashboardFitnessAndHealthStats": "Fitness And Health Stats",
                "DashboardManufacturing": "Manufacturing"
            }
        },
        {
            category: "Sales Dashboards",
            reports: {
                "DashboardSalesByCompanies": "Sales By Companies",
                "DashboardVehicleProduction": "Vehicle Production",
                "DashboardSummary": "Summary"
            }
        },
        {
            category: "Social Dashboards",
            reports: {
                "DashboardSaaSMetrics": "SaaS Metrics",
                "DashboardSaaSKPI": "SaaS KPI",
                "DashboardCustomerServiceKPI": "Customer Service KPI",
                "DashboardManufacturingKPI": "Manufacturing KPI",
                "DashboardRetailKPI": "Retail KPI"
            }
        },
        {
            category: "Education Dashboards",
            reports: {
                "DashboardEducation": "Education",
                "DashboardFinancesKPI": "Finances KPI",
                "DashboardStudentsKPI": "Students KPI"
            }
        },
        {
            category: "Healthcare Dashboards",
            reports: {
                "DashboardFinanceKPI": "Finance KPI",
                "DashboardHospitalOverview": "Hospital Overview",
                "DashboardHospitalPerformance": "Hospital Performance",
                "DashboardMedical": "Medical",
                "DashboardPatientHealthKPI": "Patient Health KPI",
                "DashboardPatientSatisfaction": "Patient Satisfaction",
                "DashboardPublicHealthKPI": "Public Health KPI"
            }
        },
        {
            category: "Statistics Dashboards",
            reports: {
                "DashboardExchangeTenders": "Exchange Tenders",
                "DashboardOrders": "Orders",
                "DashboardRestaurantAttendanceTracking": "Restaurant Attendance Tracking",
                "DashboardWebsiteAnalytics": "Website Analytics",
                "DashboardUserActivityStats": "User Activity Stats"
            }

        },
        {
            category: "Real-life Dashboards",
            reports: {
                "DashboardAlibabaRevenue": "Alibaba Revenue",
                "DashboardChinaConstructionBank": "China Construction Bank",
                "DashboardInternetApplicationTrendsInChina": "Internet Application Trends in China",
                "DashboardManufactureInChina": "Manufacture in China",
                "DashboardOPECOilProduction": "OPEC Oil Production",
                "DashboardTopOfExpensiveBuildingsInChina": "Top of Expensive Buildings in China",
                "DashboardWorldElectricityConsumptionPerCapita": "World Electricity Consumption per Capita",
                "DashboardUsersStatisticRegionalMap": "Users Statistic Regional Map"
            }
        }
    ]

    for (var i = 0; i < allReports.length; i++) {
        reportsContainer.appendChild(stiCategoryHeader(allReports[i].category));

        for (var reportName in allReports[i].reports) {
            var button = stiReportButton(allReports[i].reports[reportName], "/images/Dashboard_x2.png");
            reportsContainer.appendChild(button);
            button.reportName = reportName;
            button.id = reportName;
            reportButtonsId.push(button.id);
        }
    }
}

function stiReportButton(text, imageName) {
    var button = document.createElement("div");
    button.className = "stiReportButton";
    button.style.display = "block";
    button.style.cursor = "pointer";

    var table = document.createElement("table");
    table.cellPadding = 0;
    table.cellSpacing = 0;
    button.appendChild(table);

    var tr = document.createElement("tr");
    table.appendChild(tr);

    if (imageName) {
        var img = document.createElement("img");
        img.style.width = img.style.height = "18px";
        img.style.margin = "5px 5px 5px 8px";
        img.src = imageName;

        var imageCell = document.createElement("td");
        tr.appendChild(imageCell);
        imageCell.appendChild(img);
    }

    if (text) {
        var textCell = document.createElement("td");
        textCell.style.whiteSpace = "nowrap";
        textCell.innerHTML = text;
        tr.appendChild(textCell);
    }

    button.onmouseover = function () {
        this.className = "stiReportButtonOver";
    }

    button.onmouseout = function () {
        this.className = button.isSelected ? "stiReportButtonSelected" : "stiReportButton";
    };

    button.onclick = function () {
        loadReportToViewer(this.reportName);
    }

    return button;
}

function mainFrameLoadComplete() {
    hideProgress();
}

function setSelectedReportButton(reportName) {
    for (i = 0; i < reportButtonsId.length; i++) {
        var reportButton = document.getElementById(reportButtonsId[i]);
        if (reportButton) {
            reportButton.isSelected = reportButtonsId[i] == reportName;
            reportButton.className = reportButton.isSelected ? "stiReportButtonSelected" : "stiReportButton";
        }
    }
}

function loadReportToViewer(reportName) {
    setSelectedReportButton(reportName);

    var mainFrame = document.getElementById("stiMainFrame");
    mainFrame.src = "/View/Dashboards/" + reportName;
    showProgress();
}

function stiCategoryHeader(text) {
    var header = document.createElement("div");
    header.className = "stiCategoryHeader";
    header.innerHTML = text;

    return header;
}

function stiProgress() {
    var progressContainer = document.createElement("div");
    progressContainer.className = "stiProgressContainer";

    var progress = document.createElement("div");
    progressContainer.appendChild(progress);
    progress.className = "mobile_designer_loader";

    return progressContainer;
}

function showProgress() {
    hideProgress();
    var rightPanel = document.getElementById("RightPanel");
    var progress = stiProgress();
    rightPanel.appendChild(progress);
    rightPanel.progress = progress;
}

function hideProgress() {
    var rightPanel = document.getElementById("RightPanel");
    if (rightPanel.progress) {
        rightPanel.removeChild(rightPanel.progress);
        rightPanel.progress = null;
    }
}