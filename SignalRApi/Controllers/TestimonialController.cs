using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
               Comment = createTestimonialDto.Comment,
               ImageUrl = createTestimonialDto.ImageUrl,
               Name = createTestimonialDto.Name,
               Status = createTestimonialDto.Status,
               Title = createTestimonialDto.Title,
            });
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            { 
              ImageUrl = updateTestimonialDto.ImageUrl,
              Comment = updateTestimonialDto.Comment,
              Name = updateTestimonialDto.Name,
              Status = updateTestimonialDto.Status,
              Title = updateTestimonialDto.Title,
              TestimonialId = updateTestimonialDto.TestimonialId
            });
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
        }
    }
}