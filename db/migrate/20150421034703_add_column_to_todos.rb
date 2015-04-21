class AddColumnToTodos < ActiveRecord::Migration
  def change
    add_column :todos, :user_id, :int
  end
end
