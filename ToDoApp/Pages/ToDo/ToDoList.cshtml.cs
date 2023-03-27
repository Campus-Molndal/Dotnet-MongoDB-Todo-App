using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Pages.ToDo;

public class ToDoListModel : PageModel
{
    private readonly IToDoService _toDoService;

    public ToDoListModel(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    public IEnumerable<ToDoItem> ToDoItems { get; private set; }

    public async Task<IActionResult> OnGetAsync()
    {
        ToDoItems = await _toDoService.GetAllAsync();
        foreach (var item in ToDoItems)
        {
            Console.WriteLine("Title: {0}", item.Title);
            Console.WriteLine("Details: {0}", item.Details);
            Console.WriteLine("IsCompleted: {0}", item.IsCompleted);
            Console.WriteLine("-----------");
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string title, string details)
    {
        var newItem = new ToDoItem { Title = title, Details = details, IsCompleted = false };
        await _toDoService.CreateAsync(newItem);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostToggleStatusAsync(string id)
    {
        var item = await _toDoService.GetByIdAsync(id);
        if (item != null)
        {
            item.IsCompleted = !item.IsCompleted;
            await _toDoService.UpdateAsync(id, item);
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        await _toDoService.DeleteAsync(id);
        return RedirectToPage();
    }

}