using Microsoft.AspNetCore.Mvc;
using _1_Application.Models.ViewModels;
using _1_Application.Data;
using _1_Application.Models.Domain;
using _1_Application.Repo;
using Microsoft.EntityFrameworkCore;

namespace _1_Application.Controllers;
public class AdminTagsController : Controller
{
     private readonly ITagRepository _tagRepository;

    public AdminTagsController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }

    [HttpPost]
    [ActionName("Add")]
    public async Task<IActionResult> AddTag(AddTagRequest addTagRequest)
    {
        var name = addTagRequest.Name;
        var displayName = addTagRequest.DisplayName;

        var tag = new Tag
        {
            Name = addTagRequest.Name,
            DisplayName=addTagRequest.DisplayName
        };

        var tags = await _tagRepository.AddTagAsync(tag);
        
        return RedirectToAction("List");

    }
    [HttpGet]
    [ActionName("List")]
    public async Task<IActionResult> List()
    {
        var tags = await _tagRepository.GetAllAsync();
        return View(tags);
    }

    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(long id)
    {
        var tag = await _tagRepository.FindByIdAsync(id);
        if(tag == null)
        {
            return View(null);
        } 
        var editTagRequest = new EditTagRequest
        {
            Id = tag.Id,
            Name = tag.Name,
            DisplayName = tag.DisplayName
        };

        return View(editTagRequest);

    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
    {
        var tag = await _tagRepository.EditTagAysnc(editTagRequest);

        return RedirectToAction("List");
        

    }


    [HttpPost]
    public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
    {
        var tag = await _tagRepository.DeleteTagAsync(editTagRequest);
         return RedirectToAction("List");

    }

}

