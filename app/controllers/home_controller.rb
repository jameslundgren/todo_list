=begin
Authors: James Lundgre, Victor Marrufo
Date: April 23, 2015
Source code based off of tutorial found at https://www.youtube.com/watch?v=fr8u3l6RWOQ

Controller for the home page of the application. 
=end


class HomeController < ApplicationController

  # If the user is signed in, show the todo list, other wise show the signin page
  def index 
    if user_signed_in?
      redirect_to :controller => 'todo', :action => 'index'
    end
  end
end
