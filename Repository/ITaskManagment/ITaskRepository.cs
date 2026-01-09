using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.TaskManagment;

namespace Repository.ITaskManagment
{
      public interface ITaskRepository
      {
        Task<int> CreateTaskManagment(TaskModel model);
        Task<List<TaskModel>> GetAllRecord();
        Task<TaskModel> GetByIdTask(int taskId);
        Task<int> UpdateTaskManagment(TaskModel model);
        Task<int> DeleteTaskManagment(int taskId);
        Task<List<TaskModel>> SearchTaskManagment(string searchText);
      }
}
