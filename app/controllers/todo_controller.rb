=begin
Authors: James Lundgre, Victor Marrufo
Date: April 23, 2015
Source code based off of tutorial found at https://www.youtube.com/watch?v=fr8u3l6RWOQ

Controller for the todo list functionality. 
=end


class TodoController < ApplicationController
  
  # Variables for items that have been completed and haven't been completed
  def index 
    @todos = Todo.where(user_id: current_user.id, done: false)
    @todone= Todo.where(user_id: current_user.id, done: true)
  end

  # Used when a new task is added to the todo list
  def new 
    @todo = Todo.new
  end
 
  # paramaters for a todolist item (name and status boolean)
  def todo_params
    params.require(:todo).permit(:name, :done)
  end

  # Associates a todo task with a specific user when it is created
  def create
    @todo = Todo.new(todo_params)
    @todo.user = current_user

    if @todo.save
     redirect_to todo_index_path, :notice => "Your todo item was created" 
    else
      render "new"
    end
  end

  # Used when an items status is updated
  def update
    @todo = Todo.find(params[:id])
    
    if @todo.update_attribute(:done, true)
      redirect_to todo_index_path, :notice => "Your todo item was marked as done!"    
    else 
      redirect_to todo_index_path, :notice => "Your todo item was unable to be marked as done!"
    end
  end

  # used to remove a todo item from the page
  def destroy
    @todo = Todo.find(params[:id])
    @todo.destroy

    redirect_to todo_index_path, :notice => "Your todo item was deleted!"
  end
end
