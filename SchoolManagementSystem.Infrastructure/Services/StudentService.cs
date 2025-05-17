using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.DTOs.Student;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="context">The database context used to interact with the application's data store.  This parameter cannot be null.</param>
        /// <param name="mapper">The object mapper used to map between domain models and DTOs.  This parameter cannot be null.</param>
        public StudentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all students from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                return _mapper.Map<List<StudentDto>>(students);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                throw new Exception("Error retrieving students", ex);
            }
        }
        /// <summary>
        /// Gets a student by ID from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                    throw new KeyNotFoundException("Student not found");

                return _mapper.Map<StudentDto>(student);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                throw new Exception("Error retrieving student", ex);
            }
        }
        /// <summary>
        /// Gets students by class ID from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<List<StudentDto>> GetStudentsByClassAsync(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                    throw new KeyNotFoundException("Student not found");

                return _mapper.Map<List<StudentDto>>(student);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                throw new Exception("Error retrieving students by class", ex);
            }
        }
        /// <summary>
        /// Creates a new student record in the database and returns the created student details.
        /// </summary>
        /// <remarks>This method maps the provided <paramref name="studentDto"/> to a student entity, adds
        /// it to the database, and saves the changes asynchronously. The returned <see cref="StudentDto"/> contains the
        /// details of the created student, including any database-generated values such as the student ID.</remarks>
        /// <param name="studentDto">The data transfer object containing the details of the student to create.</param>
        /// <returns>A <see cref="StudentDto"/> object representing the newly created student.</returns>
        public async Task<StudentDto> CreateStudentAsync(CreateStudentDto studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return _mapper.Map<StudentDto>(student);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                throw new Exception("Error creating student", ex);
            }
        }
        /// <summary>
        /// Updates the details of an existing student in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the student to update.</param>
        /// <param name="studentDto">An object containing the updated student details.</param>
        /// <returns>A <see cref="StudentDto"/> object representing the updated student.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if a student with the specified <paramref name="id"/> is not found.</exception>
        public async Task<StudentDto> UpdateStudentAsync(int id, UpdateStudentDto studentDto)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                    throw new KeyNotFoundException("Student not found");

                _mapper.Map(studentDto, student);
                _context.Students.Update(student);
                await _context.SaveChangesAsync();

                return _mapper.Map<StudentDto>(student);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                throw new Exception("Error updating student", ex);
            }
        }
        /// <summary>
        /// DEletes a student from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<int> DeleteStudentAsync(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                    throw new KeyNotFoundException("Student not found");

                _context.Students.Remove(student);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                throw new Exception("Error deleting student", ex);
            }
        }
    }
}
