=begin
Authors: James Lundgre, Victor Marrufo
Date: April 23, 2015
Source code based off of tutorial found at https://www.youtube.com/watch?v=fr8u3l6RWOQ
=end

class ApplicationController < ActionController::Base
  # Prevent CSRF attacks by raising an exception.
  # For APIs, you may want to use :null_session instead.
  protect_from_forgery with: :exception
end
