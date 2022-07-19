﻿using System;
using AreaLibrary.Models;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.DepartmentPage
{
    public partial class DepartmentModal : ComponentBase
    {
        [Inject]
        private DepartmentService _departmentService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private Virtualize<Department> _virtualizeContainer { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modal { get; set; }

        private Guid _modalTarget { get; set; }

        private Department _department { get; set; }

        private List<Department> _departments { get; set; }
        private List<Department> _searchResults { get; set; }

        private bool _displayValidationErrorMessages { get; set; }
        private bool _hasSearchResults { get; set; }
        private bool _isEnableAddDepartment { get; set; }

        private string _searchTerm { get; set; }

        public DepartmentModal()
        {
            _toastService = new();
            _spinnerService = new();
            _virtualizeContainer = new();
            _modal = new();
            _departments = new List<Department>();
            _searchResults = new List<Department>();
            _department = new();
            _hasSearchResults = false;
            _isEnableAddDepartment = false;
            _searchTerm = string.Empty;
        }

        public async Task OpenModalAsync()
        {
            _modalTarget = Guid.NewGuid();

            await Task.FromResult(_modal.Open(_modalTarget));
            await Task.CompletedTask;
        }

        private async Task SearchAsync(ChangeEventArgs eventArgs)
        {
            var searchTerm = eventArgs?.Value?.ToString();
            _hasSearchResults = true;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                _searchResults = new List<Department>();
                _hasSearchResults = false;
                await Task.CompletedTask;
            }
            else
            {
                _searchResults = await _departmentService.SearchAsync(searchTerm);
                await Task.CompletedTask;
            }
        }

        private async ValueTask<ItemsProviderResult<Department>> LoadDepartments(ItemsProviderRequest request)
        {
            _departments = await _departmentService.GetDepartmentsAsync();

            await Task.Run(() => _spinnerService.HideSpinner());
            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<Department>(
                _departments.Skip(request.StartIndex).Take(request.Count), _departments.Count
            );
        }

        private async Task UpdateDepartmentStatusAsync(Department department)
        {
            department.IsActive = !department.IsActive;

            await Task.FromResult(_departmentService.UpdateDepartmentAsync(department));
            await Task.CompletedTask;
        }

        private async Task EnableFormAddDepartmentAsync()
        {
            _isEnableAddDepartment = true;
            await Task.CompletedTask;
        }

        private async Task DisableFormAddDepartmentAsync()
        {
            FormInitialState();
            await Task.CompletedTask;
        }

        private async Task EditDepartmentAsync()
        {
            await Task.CompletedTask;
        }

        private async Task CloseModalAsync()
        {
            FormInitialState();

            await Task.FromResult(_modal.Close(_modalTarget));
            await OnSubmitSuccess.InvokeAsync();
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {

            _displayValidationErrorMessages = false;

            await _departmentService.AddDepartmentAsync(_department);
            await OnSubmitSuccess.InvokeAsync();
            await RefreshVirtualizeContainer();

            _toastService.ShowToast("Department added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);
            await DisableFormAddDepartmentAsync();
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task RefreshVirtualizeContainer()
        {
            await _virtualizeContainer.RefreshDataAsync();
        }

        private void FormInitialState()
        {
            _department = new Department();
            _isEnableAddDepartment = false;
            _displayValidationErrorMessages = false;
        }
    }
}