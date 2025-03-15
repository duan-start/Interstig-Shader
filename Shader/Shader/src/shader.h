#pragma once

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <glad/glad.h>
#include <string>

class shader
{
public:
	//id
	unsigned int m_ID;
	//����Դ�루����������ڵģ��������ⲿ���ģ�
	shader(const char* vertexpath, const char* fragmentpath);
	//������ɫ��
	void Init(const char* vertexpath, const char* fragmentpath);
	void use();
	//ʹ��uniform ����
	void setBool(const std::string& name, bool value) const;
	void setInt(const std::string&  name, int  value) const;
	void setFloat(const std::string& name, float value) const;
	void setMatrix4fv(const std::string& name,glm::mat4 value) const;
	void setVec2(const std::string& name,  glm::vec2 value) const;
    void setVec3(const std::string& name, glm::vec3 value) const;
private:
    // utility function for checking shader compilation/linking errors.
    // ------------------------------------------------------------------------
	void checkCompileErrors(unsigned int shader, std::string type);
    
};
