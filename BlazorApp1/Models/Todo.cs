
namespace ToDoPrj;

public class Todo
{          
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsFinished { get; set; } = false;

    public DateTime  CreatedAt {  get; set; } = DateTime.Now;

    public DateTime? FinishedAt { get; set; }

    public bool IsEditing { get; set; }


    public static Todo NewTodo()
    {
         var todo  = new Todo()
         {
             Name = "new todo"
         };

         TodoRepository.AddTodo(todo);
         return todo;
    }                          

}





public static class TodoRepository
{
    private static readonly List<Todo> Todos =
    [
        new Todo { Id = 1, Name = "Todo Item 1", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 2, Name = "Todo Item 2", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-1) },
        new Todo { Id = 3, Name = "Todo Item 3", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 4, Name = "Todo Item 4", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-3) },
        new Todo { Id = 5, Name = "Todo Item 5", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 6, Name = "Todo Item 6", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-5) },
        new Todo { Id = 7, Name = "Todo Item 7", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 8, Name = "Todo Item 8", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-7) },
        new Todo { Id = 9, Name = "Todo Item 9", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 10, Name = "Todo Item 10", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-9) },
        new Todo { Id = 11, Name = "Todo Item 11", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 12, Name = "Todo Item 12", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-11) },
        new Todo { Id = 13, Name = "Todo Item 13", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 14, Name = "Todo Item 14", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-13) },
        new Todo { Id = 15, Name = "Todo Item 15", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 16, Name = "Todo Item 16", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-15) },
        new Todo { Id = 17, Name = "Todo Item 17", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 18, Name = "Todo Item 18", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-17) },
        new Todo { Id = 19, Name = "Todo Item 19", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 20, Name = "Todo Item 20", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-19) },
        new Todo { Id = 21, Name = "Todo Item 21", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 22, Name = "Todo Item 22", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-21) },
        new Todo { Id = 23, Name = "Todo Item 23", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 24, Name = "Todo Item 24", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-23) },
        new Todo { Id = 25, Name = "Todo Item 25", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 26, Name = "Todo Item 26", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-25) },
        new Todo { Id = 27, Name = "Todo Item 27", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 28, Name = "Todo Item 28", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-27) },
        new Todo { Id = 29, Name = "Todo Item 29", IsFinished = false, FinishedAt = DateTime.MinValue },
        new Todo { Id = 30, Name = "Todo Item 30", IsFinished = true, FinishedAt = DateTime.Now.AddDays(-29) }
    ];


    public static void AddTodo(Todo server)
    {
        var maxId = Todos.Max(s => s.Id);
        server.Id = maxId + 1;
        Todos.Add(server);
    }

    public static List<Todo> GetTodos()
    {
        return Todos;
    }

    public static List<Todo> GetTodosByDate(DateTime createAt)
    {
        return Todos.Where(s => s.CreatedAt.Date == createAt).ToList();
    }

    public static Todo? GetTodoById(int id)
    {
        var todo = Todos.FirstOrDefault(s => s.Id == id);
        if (todo != null)
            return new Todo
            {
                Id = todo.Id,
                Name = todo.Name,
              CreatedAt = todo.CreatedAt,
              FinishedAt = todo.FinishedAt,
               IsFinished = todo.IsFinished
            };

        return null;
    }

    public static void UpdateTodo(int todoId, Todo todo)
    {
        if (todoId != todo.Id) return;

        var todoToUpdate = Todos.FirstOrDefault(s => s.Id == todoId);

        if (todoToUpdate == null) return;

        todoToUpdate.Name = todo.Name;
        if(todo.IsFinished)
            todoToUpdate.FinishedAt = DateTime.Now;

        todoToUpdate.IsFinished = todo.IsFinished;
    }

    public static void DeleteTodo(int todoId)
    {
        var todo = Todos.FirstOrDefault(s => s.Id == todoId);
        if (todo != null) Todos.Remove(todo);
    }

    public static List<Todo> SearchTodos(string serverFilter)
    {
        return Todos.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}