using Dapper;
using DataLayer.TaskManagment;
using ModelLayer.TaskManagment;
using Repository.ITaskManagment;
using System.Data;

public class TaskRepository : ITaskRepository
{
    #region CREATE
    public async Task<int> CreateTaskManagment(TaskModel model)
    {
        using (var _db = ConnectionFactory.DbConnection())
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TaskTitle", model.TaskTitle);
            parameter.Add("@TaskDescription", model.TaskDescription);
            parameter.Add("@TaskDueDate", model.TaskDueDate);
            parameter.Add("@TaskStatus", model.TaskStatus);
            parameter.Add("@TaskRemarks", model.TaskRemarks);
            parameter.Add("@CreatedById", model.CreatedById);
            parameter.Add("@CreatedByName", model.CreatedByName);

            return await _db.QuerySingleAsync<int>(
                "USP_Task_Create",
                parameter,
                commandType: CommandType.StoredProcedure
            );
        }
    }
    #endregion

    #region READ ALL
    public async Task<List<TaskModel>> GetAllRecord()
    {
        using (var _db = ConnectionFactory.DbConnection())
        {
            var result = await _db.QueryAsync<TaskModel>(
                "USP_Task_GetAll",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
    }
    #endregion

    #region READ BY ID
    public async Task<TaskModel?> GetByIdTask(int taskId)
    {
        using (var _db = ConnectionFactory.DbConnection())
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TaskId", taskId);

            return await _db.QuerySingleOrDefaultAsync<TaskModel>(
                "USP_Task_GetById",
                parameter,
                commandType: CommandType.StoredProcedure
            );
        }
    }
    #endregion

    #region UPDATE
    public async Task<int> UpdateTaskManagment(TaskModel model)
    {
        using (var _db = ConnectionFactory.DbConnection())
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TaskId", model.TaskId);
            parameter.Add("@TaskTitle", model.TaskTitle);
            parameter.Add("@TaskDescription", model.TaskDescription);
            parameter.Add("@TaskDueDate", model.TaskDueDate);
            parameter.Add("@TaskStatus", model.TaskStatus);
            parameter.Add("@TaskRemarks", model.TaskRemarks);
            parameter.Add("@UpdatedById", model.UpdatedById);
            parameter.Add("@UpdatedByName", model.UpdatedByName);

            return await _db.QuerySingleAsync<int>(
                "USP_Task_Update",
                parameter,
                commandType: CommandType.StoredProcedure
            );
        }
    }
    #endregion

    #region DELETE
    public async Task<int> DeleteTaskManagment(int taskId)
    {
        using (var _db = ConnectionFactory.DbConnection())
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TaskId", taskId);

            return await _db.QuerySingleAsync<int>(
                "USP_Task_Delete",
                parameter,
                commandType: CommandType.StoredProcedure
            );
        }
    }
    #endregion

    #region SEARCH
    public async Task<List<TaskModel>> SearchTaskManagment(string searchText)
    {
        using (var _db = ConnectionFactory.DbConnection())
        {
            var parameter = new DynamicParameters();
            parameter.Add("@SearchText", searchText);

            var result = await _db.QueryAsync<TaskModel>(
                "USP_Task_Search",
                parameter,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
    }
    #endregion
}
