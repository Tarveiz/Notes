﻿using Notes.DAL.Interface;
using Notes.Domain.Entity;
using Notes.Domain.Response;
using Notes.Services.Interface;
using Notes.Domain.Enum;
using Notes.Domain.Interface;

namespace Notes.Services.Implementation
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INoteRepository repository)
        {
            _noteRepository = repository;
        }
        public async Task<IBaseResponse<IEnumerable<Note>>> GetNotes()
        {
            var baseResponse = new BaseResponse<IEnumerable<Note>>();
            try
            {
                var notes = await _noteRepository.Get();
                if(notes.Count == 0)
                {
                    baseResponse.Description = "Не найдено ни одного элемента";
                    baseResponse.StatusCode = StatusCode.Success;
                    return baseResponse;
                }
                baseResponse.Data = notes;
                baseResponse.StatusCode = StatusCode.Success;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Note>>()
                {
                    Description = $"{this.GetType()} : {ex.Message}"
                };
            }
        }
    }
}
