#version 330 core

// ���붥������
layout(location = 0) in vec3 aPos;      // ����λ��
// �����Ƭ����ɫ���ı���
out vec2 Pos;
out vec2 stand;
uniform vec2 iResolution;
out vec2 screen;

// ������ɫ��������
void main() {
    // ���ö���λ��
    gl_Position = vec4(aPos, 1.0);

    // ���������괫�ݵ�Ƭ����ɫ��

    Pos = vec2((aPos.x+1)*iResolution.x/2,(aPos.y+1)*iResolution.y/2);
    stand=vec2(aPos.x,aPos.y);
    screen=iResolution;
}